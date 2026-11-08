# Granny Legacy Documentation

Reverse engineering findings for Granny Legacy, documented as one C++ source file per class with the full decompiled bodies in `src/`, rendered by Doxygen.

**Reminder:** hardcoded offsets break between versions. Prefer finding things through the game assemblies.

## Conventions

- One file per class: `src/<Class>.cpp`, a C++ class holding fields and methods, with the IDA pseudocode pasted as each method body.
- Every class, field and method gets a short `/// @brief`. Use `@details` for behaviour and `@note` for modding tips.
- Field offsets go in a trailing `///< offset 0x..` comment. Methods not yet reverse engineered are empty stubs.
- Scratch research goes in `notes/`.

## Build

Install [Doxygen](https://www.doxygen.nl/), then run `serve.bat`. Output is `doxygen/html/index.html`.
