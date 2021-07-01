@echo off

chcp 65001

set configuration=%~1
set output_directory=%~2

if [%configuration%] == [] goto err_configuration_is_empty
if ["%output_directory%"] == [] goto err_output_directory_is_empty

echo Проект в конфигурации %configuration% будет опубликован в папку %output_directory%

set PATH_old=%PATH%

set PATH="C:\Program Files\nodejs";%PATH%

cd ..

echo Сборка проекта в конфигурации %configuration% началась
call npm i
call npm run build --%configuration%
echo Сборка проекта в конфигурации %configuration% завершилась

echo Копирование результата сборки в папку публикации %output_directory% началась
robocopy .\build "%output_directory%" /mir
echo Копирование результата сборки в папку публикации %output_directory% завершилось

cd deploy

set PATH=%PATH_old%

goto end

:err_configuration_is_empty
echo Параметр "Конфигурация сборки" (первый) не указан

:err_output_directory_is_empty
echo Параметр "Папка публикации" (второй) не указан

:end