@echo off

chcp 65001

set configuration=%~1
set output_directory=%~2

set PATH_old=%PATH%

set PATH="C:\Program Files\dotnet";%PATH%

set project_name=Makc2021.Layer3.Sample.Clients.SqlServer.EF

echo Обновление базы данных проекта %project_name% началось
cd ..\..\src\%project_name%
dotnet ef database update --configuration %configuration%
cd ..
echo Обновление базы данных проекта %project_name% завершилось

echo Очистка предназначенной для публикации папки %output_directory% началась
del /q %output_directory%\*
for /D %%p IN (%output_directory%\*.*) DO rmdir "%%p" /s /q
echo Очистка предназначенной для публикации папки %output_directory% завершилась

set project_name=Makc2021.Layer6.Apps.WebHttpServer

echo Публикация проекта %project_name% в конфигурации %configuration% началась
cd %project_name%
dotnet publish -c %configuration% -o %output_directory%
echo Публикация проекта %project_name% в конфигурации %configuration% завершилась

set PATH=%PATH_old%

cd ..\..\deploy\WebHttpServer