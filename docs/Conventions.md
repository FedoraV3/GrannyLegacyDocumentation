---
title: Conventions
nav_order: 90
---

# Conventions

This document is the schema every other page follows. It exists so that a reader who
has read one page already knows how to read the next one, and so that pages written
months apart still line up side by side.

It is enforced by review, not by tooling. If a page does not match this document,
either the page is wrong or this document is — decide which, and fix that one.

**Scope:** everything under `docs/`. `notes/` is a scratchpad and follows no rules.

---

## 1. The one-heading rule

**Exactly one `#` per page, and it is the name of the thing the page is about.
Every section is `##`.**

The theme does *not* render `page.title` as a heading, so the `#` line is the page's
only visible title. Two H1s means the page has two titles. Zero H1s means it has none,
and the heading anchors that `heading_anchors: true` generates collapse.

Beyond the H1, never skip a level. `##` then `###`, never `##` then `####`.

| Page | H1 |
|---|---|
| `AI_Granny/index.md` | `# AI_Granny` |
| `AI_Granny/Start.md` | `# Start` |
| `AI_Behaviour/index.md` | `# AI Behaviour` |
| `Conventions.md` | `# Conventions` |

Sections that describe behaviour — `Behaviour`, `Notes`, `Touches` — must be real
headings, not `**bold text**`. Bold labels are invisible to anchors, the search index,
and the on-page table of contents.

---

## 2. Page types

Four shapes. Pick one before you write, because the section order is fixed per type.

### 2.1 Class page — `docs/<Category>/<Class>/index.md`

A **hub**, not a dump. Its job is to orient a reader and route them to method pages.

```markdown
# AI_Granny

## Provenance
## Class Definition
## Method Index
## Behaviour Overview
## Related
```

- `## Class Definition` holds the raw Il2CppDumper output **unchanged**. This is the
  one place in the docs where a raw, un-edited dump is the primary artifact, because
  it is reference data rather than something to be read narratively.
- `## Method Index` is a table of every method, **in C# class-definition order**,
  each name linked to its page. Unwritten methods appear as `—`, not as broken links.
- `## Behaviour Overview` is optional and only for AI classes. A Mermaid
  `stateDiagram-v2` plus a threshold table. Omit entirely if the class has no behaviour.

### 2.2 Method page — `docs/<Category>/<Class>/<Method>.md`

```markdown
# DeadDisable

## Signature
## Address
## Decompiled
## Behaviour
## Touches
## Callers
## Notes
## Related
```

**Order is fixed. Sections may be omitted, never reordered.** A 256-byte method does
not need `## Callers`; a pure setter does not need `## Behaviour`. But whatever is
present appears in the order above.

`## Touches` is the highest-value section in this documentation and should be present
whenever the method reads or writes object state. It is a table of fields:

```markdown
| Field | Offset | R/W | What happens |
|---|---|---|---|
| `CaughtPlayer` | 0x188 | W | set to `false` |
| `Agent` | 0xA8 | W | `enabled = false` |
```

This is what a modder actually opens these pages for, and it is the section that makes
offsets documented rather than merely referenced.

### 2.3 Coroutine page

IL2CPP splits a coroutine into a stub plus a compiler-generated `<Name>d__N` state
machine, and **the real logic lives in `MoveNext`**. A page documenting only the stub
is actively misleading.

One page per coroutine, named after the coroutine method (`SmackTimer.md`), containing
both:

```markdown
# SmackTimer

## Signature
## Address
## Decompiled
## State Machine
## Behaviour
## Touches
## Related
```

`## State Machine` documents `AI_Granny.<SmackTimer>d__139$$MoveNext` — its states,
its `yield` points, and the field that drives it. A Mermaid `stateDiagram-v2` is
preferred over prose here.

Never create a file named after `MoveNext` or containing `<>`. Those characters are
hostile to URLs and to every tool that touches the repo.

### 2.4 Explanation page

Only when a topic outgrows a section on its own page. Not a default. If you are unsure
whether you need one, you do not need one — put it in `## Behaviour Overview`.

---

## 3. Frontmatter

Fixed schema, fixed key order. Omit what does not apply; never invent keys ad hoc.

```yaml
---
title: DeadDisable
parent: AI Granny
nav_order: 50
status: draft
game_version: TBD
---
```

| Key | Required | Notes |
|---|---|---|
| `title` | always | The H1 text, and the sidebar label |
| `parent` | when nested | The **`title`** of the parent page, not its folder |
| `grand_parent` | no | Not needed — nesting works from `parent` alone |
| `has_children` | class pages | `true` |
| `nav_order` | always | See §6 |
| `layout` | no | `_config.yml` sets `default` for everything; `index.md` overrides with `home` |
| `status` | always | `stub` · `draft` · `complete` — see §9 |
| `game_version` | always | The build this was measured against |

---

## 4. Code listings

Every non-trivial listing appears twice: a **cleaned** copy for reading, and the
**raw** Hex-Rays output inside a collapsed `<details>` for verification.

````markdown
## Decompiled

```cpp
// Fidelity: metadata init elided; method: nullptr dropped; v14 → steamApiFile
...
```

<details><summary>Raw Hex-Rays output</summary>

```cpp
...
```
</details>
````

### 4.1 The fidelity line

The **first line** of every cleaned block is a comment beginning `// Fidelity:` stating
exactly what was altered. If nothing was altered, write:

```cpp
// Fidelity: verbatim
```

This line is what separates editing from lying. A reader who cannot trust a listing
cannot use it, and a reader who cannot see what changed cannot check it.

### 4.2 What may be elided

| Elide | To | Why |
|---|---|---|
| `il2cpp_codegen_initialize_runtime_metadata` init blocks | one `// metadata init` line | Boilerplate, identical on every page |
| `method: nullptr` arguments | nothing | Always null in this build |
| Named-argument labels (`a1:`, `this:`, `key:`) | positional | Only noise once the callee is obvious |
| Overload suffixes (`_7508944`, `_7329808`) | dropped | Il2CppDumper disambiguation, not semantics |
| `v14`, `string_result_1`, `Bats_1` | semantic names | A reader should not need a symbol table |
| `_2.cctor_finished` static-init guards | elided | **Only** when they do not alter control flow |

### 4.3 What must never be elided

- Null checks that reach `il2cpp_codegen_raise_null_reference_exception` — they are the
  actual contract of the method.
- `try` / `catch` paths. `GameInputManager$$Start` quits the game from inside one.
- `goto` labels that carry real branching.
- Field offsets in anything that documents an offset.

### 4.4 Style

- Keep `Class$$Method` as the separator. It is unambiguous and matches the IDB.
- Keep `this->fields.X`. The `fields` access is where the offset lives; flattening it
  hides the one piece of information every reader wants.
- Comments explain **why**, not what. `// lol` and `// this doesn't do anything about
  inputs` are good comments. `// set Run_Speed to 3.8` is not.

Before:

```cpp
Run_Speed = UnityEngine.PlayerPrefs$$GetInt_7508944(key: str_Difficulty, method: nullptr);
```

After:

```cpp
Run_Speed = PlayerPrefs$$GetInt(str_Difficulty);
```

### 4.5 Addresses

Every `## Address` states the IDB address, the size, and the full symbol:

```markdown
`0x1bdd60` · 256 bytes · `AI_Granny$$DeadDisable`
```

Addresses are **version-dependent** and that is fine — `game_version` records which
build they belong to. An undocumented offset is worse than a versioned one.

---

## 5. Linking

Use Jekyll's `{% raw %}{% link %}{% endraw %}` tag, never a bare path:

````markdown
[Start]({% raw %}{% link docs/AI_Behaviour/AI_Granny/Start.md %}{% endraw %})
````

Bare paths 404 silently in public and look fine locally. The link tag **fails the
build** when its target is missing, which turns a class of typo into a build error.
That is the entire difference between tidy and standard.

Every page ends with `## Related` listing siblings worth reading next.

> **Gotcha** — Liquid runs *before* Markdown, so a link tag written inside a fenced
> code block still executes and still fails the build. Wrap any example of a Liquid
> tag in a `raw` block — the `raw` tag before it, the `endraw` tag after — exactly as
> above.

---

## 6. Navigation order

`nav_order` is always explicit. Without it the theme sorts alphabetically, which is
why `DeadDisable` currently appears before `Start` in the sidebar.

**Order in tens** — `10, 20, 30` — so inserting a page never forces renumbering.

| Level | Scheme |
|---|---|
| Top level | Introduction `1` · Getting Started `3` · documentation sections from `10` · Conventions `90` |
| Class within a category | `10, 20, 30…` in whatever order makes sense for the category |
| Method within a class | `10, 20, 30…` **in C# class-definition order** |

Class-definition order, not alphabetical: a reader walks a `MonoBehaviour` from `Start`
downward, and the sidebar should agree with the class listing on the hub page.

---

## 7. Page status

| `status` | Meaning | Visible on site |
|---|---|---|
| `stub` | Frontmatter only, or less than a heading | **No** — also add `nav_exclude: true` |
| `draft` | Real content, may be incomplete or unverified | Yes |
| `complete` | Has all applicable sections and a `## Touches` table | Yes |

A stub must carry `nav_exclude: true`. An empty page in a published sidebar reads
as an abandoned project, which is a worse first impression than a short one.

---

## 8. Naming

| Thing | Rule | Example |
|---|---|---|
| Class directory | Exact C# type name | `AI_Granny/`, `GameInputManager/` |
| Category directory | Descriptive, `Title_Case` | `AI_Behaviour/` |
| Category page | Always `index.md` | — |
| Method file | Exact C# method name, case preserved | `DeadDisable.md` |
| Constructor | `ctor.md`, title `Constructor` | — |
| Coroutine | The coroutine's own name | `SmackTimer.md` |
| Overloads | One page per name; distinguish with `## Overloads` | `SensorPlayer.md` |

Do not create a directory per method. Do not encode the class name into a method
filename — the directory already does that, and `AI_Granny_Start.md` breaks every link
the day the class is renamed.

---

## 9. Provenance

Every class page carries a `## Provenance` table. It is the difference between
documentation and folklore once the game patches:

| Item | Value |
|---|---|
| Game version | vX.Y.Z |
| `GameAssembly.dll` SHA-256 | … |
| `global-metadata.dat` | … |
| Tools | Il2CppDumper x.y · IDA 9.x |
| Measured | 2026-10-23 |

Hashes come free from the IDB's module info. Do not guess a version number — write
`TBD` and mean it.

---

## 10. Writing

- **First person is welcome.** These are findings, not a manual. `I renamed these`
  beats a passive voice pretending the knowledge appeared from nowhere.
- **Separate fact from suspicion, explicitly.** Mark guesses:

  ```markdown
  > **Speculation** — the class name looks like bait. Unconfirmed.
  ```

  A future reader must be able to tell what was decompiled from what was inferred.
  This matters more than tidiness.
- **Blockquotes with bold labels**, not `> [!NOTE]` alerts — kramdown does not render
  GitHub's alert syntax and would print the marker literally.
- Keep the asides. They are the reason this reads like a person wrote it.

---

## 11. Definition of done

A method page is complete when:

- [ ] Frontmatter has `title`, `parent`, `nav_order`, `status: complete`
- [ ] Exactly one `#`, matching `title`
- [ ] `## Signature` has the C# prototype
- [ ] `## Address` has address, size, and symbol
- [ ] `## Decompiled` has a cleaned block with a `// Fidelity:` line, and raw in `<details>`
- [ ] `## Behaviour` bullets are prose a non-reverser can follow
- [ ] `## Touches` lists every field read or written, with offsets
- [ ] `## Related` links siblings via the `link` tag, not a bare path
- [ ] No stub sections, no `TODO` left visible
- [ ] Sidebar order still matches the class definition order

A class page is complete when the `## Method Index` links resolve and `## Provenance`
has real values rather than `TBD`.
