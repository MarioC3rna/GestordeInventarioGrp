@echo off
echo ===============================================
echo    CONFIGURACI�N DIRECTORIO IM�GENES VM
echo ===============================================
echo.

echo 1. Informaci�n del sistema:
echo    - IP VM: 172.16.92.128
echo    - Directorio objetivo: C:\ImagenesDB
echo.

echo 2. Verificando directorio C:\ImagenesDB...
if exist "C:\ImagenesDB" (
    echo    ? El directorio YA EXISTE
) else (
    echo  ? El directorio NO EXISTE - Cre�ndolo...
    mkdir "C:\ImagenesDB"
    if exist "C:\ImagenesDB" (
        echo    ? Directorio creado exitosamente
    ) else (
        echo    ? Error al crear directorio
    )
)
echo.

echo 3. Verificando permisos de escritura...
echo test > "C:\ImagenesDB\test_permisos.txt" 2>nul
if exist "C:\ImagenesDB\test_permisos.txt" (
    echo    ? Permisos de escritura OK
    del "C:\ImagenesDB\test_permisos.txt"
) else (
    echo    ? Sin permisos de escritura
)
echo.

echo 4. Listando contenido actual:
if exist "C:\ImagenesDB\*.*" (
    dir "C:\ImagenesDB" /B
    echo.
    echo    Archivos encontrados: 
    for /f %%i in ('dir "C:\ImagenesDB" /B ^| find /c /v ""') do echo    Total: %%i archivos
) else (
    echo    (Directorio vac�o)
)
echo.

echo 5. Informaci�n de la unidad C:
for /f "tokens=3" %%a in ('dir /-c C:\ ^| find "bytes free"') do echo Espacio libre: %%a bytes
echo.

echo 6. Configurando compartido de red (opcional)...
echo    Para acceso desde aplicaci�n externa, ejecutar como administrador:
echo    net share ImagenesDB=C:\ImagenesDB /GRANT:Everyone,FULL
echo.

echo 7. Creando archivo de prueba con timestamp...
echo Prueba_%date%_%time% > "C:\ImagenesDB\ultima_prueba.txt"
if exist "C:\ImagenesDB\ultima_prueba.txt" (
    echo    ? Archivo de prueba creado exitosamente
) else (
    echo  ? Error al crear archivo de prueba
)
echo.

echo ===============================================
echo         CONFIGURACI�N COMPLETADA
echo ===============================================
echo.
echo Pr�ximos pasos:
echo 1. Ejecutar la aplicaci�n C#
echo 2. Intentar guardar una imagen
echo 3. Verificar que aparezca en C:\ImagenesDB
echo.
echo Presiona cualquier tecla para continuar...
pause >nul