@echo off

chcp 65001

set configuration=%~1
set output_directory=%~2
set project_name=%~3

if [%configuration%] == [] goto err_configuration_is_empty
if ["%output_directory%"] == [] goto err_output_directory_is_empty
if [%project_name%] == [] goto err_project_name_is_empty

echo Проект %project_name% в конфигурации %configuration% будет опубликован в папку %output_directory%

set PATH_old=%PATH%

set PATH="C:\Program Files\dotnet";%PATH%

echo Очистка папки публикации %output_directory% началась
set "folder=%output_directory%"
pushd "%folder%" && (
del /q .\*
for /d %%i in (.\.) do rmdir "%%i" /s /q
popd
)
echo Очистка папки публикации %output_directory% завершилась

echo Публикация проекта %project_name% в конфигурации %configuration% началась
dotnet publish ..\..\src\%project_name%\%project_name%.csproj -c %configuration% -o "%output_directory%"
echo Публикация проекта %project_name% в конфигурации %configuration% завершилась

set PATH=%PATH_old%

goto end

:err_configuration_is_empty
echo Параметр "Конфигурация сборки" (первый) не указан

:err_output_directory_is_empty
echo Параметр "Папка публикации" (второй) не указан

:err_project_name_is_empty
echo Параметр "Имя проекта" (третий) не указан

:end