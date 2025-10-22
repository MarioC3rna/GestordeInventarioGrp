-- ?? Script para verificar y gestionar el nuevo sistema de imágenes
-- ? YA SE APLICÓ LA MIGRACIÓN DE LA BASE DE DATOS

USE Db_EmpresaDev;
GO

-- ? 1. Verificar la nueva estructura de la tabla
SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    CHARACTER_MAXIMUM_LENGTH,
    IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA = 'Invt' 
  AND TABLE_NAME = 'Tb_Productos'
  AND COLUMN_NAME LIKE '%Imagen%';

-- ? 2. Verificar qué productos tienen rutas de imagen
SELECT 
    Producto_Id,
    Producto_Codigo,
    Producto_Nombre,
    Producto_ImagenRuta,
    CASE 
        WHEN Producto_ImagenRuta IS NULL THEN 'Sin imagen'
        WHEN Producto_ImagenRuta LIKE 'C:\ImagenesDB\%' THEN 'Ruta válida del nuevo sistema'
        ELSE 'Ruta no estándar'
    END AS EstadoImagen
FROM Invt.Tb_Productos 
ORDER BY Producto_Id DESC;

-- ? 3. Estadísticas del sistema de imágenes
SELECT 
    COUNT(*) as TotalProductos,
    SUM(CASE WHEN Producto_ImagenRuta IS NULL THEN 1 ELSE 0 END) as SinImagen,
    SUM(CASE WHEN Producto_ImagenRuta IS NOT NULL THEN 1 ELSE 0 END) as ConImagen,
    SUM(CASE WHEN Producto_ImagenRuta LIKE 'C:\ImagenesDB\%' THEN 1 ELSE 0 END) as ConRutaCorrecta
FROM Invt.Tb_Productos;

-- ? 4. Ver los últimos productos ingresados con el nuevo sistema
SELECT TOP 5
    Producto_Codigo,
    Producto_Nombre,
    Producto_ImagenRuta,
    Producto_FechaIngreso
FROM Invt.Tb_Productos 
WHERE Producto_ImagenRuta IS NOT NULL
ORDER BY Producto_FechaIngreso DESC;

-- ? 5. OPCIONAL: Consulta para ver productos con su información de inventario
SELECT 
    P.Producto_Codigo,
    P.Producto_Nombre,
    P.Producto_ImagenRuta,
    ISNULL(SUM(I.Cantidad_Disponible), 0) AS Stock_Total
FROM Invt.Tb_Productos P
LEFT JOIN Invt.Tb_Inventario I ON P.Producto_Id = I.Producto_Id
WHERE P.Producto_ImagenRuta IS NOT NULL
GROUP BY P.Producto_Codigo, P.Producto_Nombre, P.Producto_ImagenRuta
ORDER BY P.Producto_Nombre;

-- ? Información sobre el directorio de imágenes
-- Para verificar en el sistema operativo:
-- DIR C:\ImagenesDB\*.png