@echo off
cd /d "%~dp0"
doxygen Doxyfile && start "" doxygen\html\index.html
