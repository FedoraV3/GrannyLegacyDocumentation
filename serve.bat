@echo off
cd /d "%~dp0"
set "PATH=C:\Ruby40-x64\bin;%PATH%"
echo starting local docs server, press ctrl+c to stop
bundle exec jekyll serve --livereload --open-url --config _config.yml,_config.local.yml
pause
