@echo off
echo ===============================================
echo    DIAGNÓSTICO IMÁGENES PERDIDAS
echo ===============================================
echo.

echo 1. Buscando archivos PRD-* en toda la unidad C:...
echo    (Esto puede tomar unos minutos)
echo.
for /f "delims=" %%i in ('dir C:\PRD-*.png /s /b 2^>nul') do (
echo    ENCONTRADO: %%i
    echo    Tamaño: 
    for %%j in ("%%i") do echo         %%~zj bytes
    echo    Fecha: 
    for %%j in ("%%i") do echo     %%~tj
    echo.
)

echo 2. Verificando directorios comunes...
echo.
set "directorios=C:\ImagenesDB C:\Users\%USERNAME%\Documents\ImagenesDB C:\Temp C:\Windows\Temp %USERPROFILE%\AppData\Local\Temp"

for %%d in (%directorios%) do (
    echo    Verificando: %%d
    if exist "%%d" (
  if exist "%%d\PRD-*.png" (
echo       ? Contiene archivos PRD-*.png:
            dir "%%d\PRD-*.png" /B 2>nul
        ) else (
    echo     - Sin archivos PRD-*.png
   )
    ) else (
        echo     - Directorio no existe
    )
    echo.
)

echo 3. Verificando directorios de aplicación...
echo.
set "app_dirs=C:\Program Files C:\Program Files (x86) %LOCALAPPDATA% %APPDATA%"

for %%a in (%app_dirs%) do (
    echo    Buscando en %%a...
    for /f "delims=" %%i in ('dir "%%a\*PRD-*.png" /s /b 2^>nul') do (
        echo  ENCONTRADO: %%i
    )
)

echo 4. Información del sistema...
echo    Usuario actual: %USERNAME%
echo    Directorio de trabajo: %CD%
echo    Variables de entorno relevantes:
echo       TEMP: %TEMP%
echo       TMP: %TMP%
echo       USERPROFILE: %USERPROFILE%
echo     LOCALAPPDATA: %LOCALAPPDATA%
echo       APPDATA: %APPDATA%
echo.

echo 5. Verificando procesos que puedan estar usando archivos...
tasklist | findstr /i "Proyecto"
echo.

echo 6. Listando todos los PNG recientes (últimas 2 horas)...
forfiles /s /m *.png /c "cmd /c echo @path - @fdate @ftime" 2>nul | findstr /i "2024"

echo.
echo ===============================================
echo         DIAGNÓSTICO COMPLETADO
echo ===============================================
echo.
echo Si encontraste archivos, anota las rutas y verifica
echo por qué no se están guardando en C:\ImagenesDB
echo.
pause