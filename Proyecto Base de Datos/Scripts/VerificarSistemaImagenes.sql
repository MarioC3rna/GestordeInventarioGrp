-- ?? Script de pruebas para el nuevo sistema de imágenes
-- Ejecutar después de probar el sistema

USE Db_EmpresaDev;
GO

-- ? 1. Verificar que el campo Producto_ImagenRuta existe y es del tipo correcto
PRINT '=== Verificación de estructura de tabla ==='
SELECT 
    TABLE_NAME,
    COLUMN_NAME,
    DATA_TYPE,
    CHARACTER_MAXIMUM_LENGTH,
    IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA = 'Invt' 
AND TABLE_NAME = 'Tb_Productos'
  AND COLUMN_NAME = 'Producto_ImagenRuta';

-- ? 2. Contar productos por tipo de imagen
PRINT '=== Estadísticas de imágenes ==='
SELECT 
    'Total de productos' as Descripcion,
    COUNT(*) as Cantidad
FROM Invt.Tb_Productos

UNION ALL

SELECT 
    'Productos sin imagen' as Descripcion,
    COUNT(*) as Cantidad
FROM Invt.Tb_Productos 
WHERE Producto_ImagenRuta IS NULL

UNION ALL

SELECT 
    'Productos con imagen' as Descripcion,
    COUNT(*) as Cantidad
FROM Invt.Tb_Productos 
WHERE Producto_ImagenRuta IS NOT NULL

UNION ALL

SELECT 
    'Productos con ruta correcta (C:\ImagenesDB)' as Descripcion,
    COUNT(*) as Cantidad
FROM Invt.Tb_Productos 
WHERE Producto_ImagenRuta LIKE 'C:\ImagenesDB\%';

-- ? 3. Mostrar últimos productos ingresados
PRINT '=== Últimos productos ingresados ==='
SELECT TOP 10
    Producto_Codigo,
    Producto_Nombre,
    Producto_ImagenRuta,
    CASE 
        WHEN Producto_ImagenRuta IS NULL THEN 'Sin imagen'
        WHEN Producto_ImagenRuta LIKE 'C:\ImagenesDB\PRD-%' THEN 'Sistema nuevo - OK'
        ELSE 'Ruta no estándar'
    END as EstadoImagen,
    Producto_FechaIngreso
FROM Invt.Tb_Productos
ORDER BY Producto_FechaIngreso DESC;

-- ? 4. Verificar integridad de rutas de imagen
PRINT '=== Verificación de integridad de rutas ==='
SELECT 
    Producto_Codigo,
    Producto_Nombre,
    Producto_ImagenRuta,
    CASE 
        WHEN Producto_ImagenRuta IS NULL THEN 'OK - Sin imagen'
  WHEN Producto_ImagenRuta LIKE 'C:\ImagenesDB\PRD-%.png' THEN 'OK - Formato correcto'
    WHEN Producto_ImagenRuta LIKE 'C:\ImagenesDB\%' THEN 'ADVERTENCIA - En directorio correcto pero formato inusual'
        ELSE 'ERROR - Ruta fuera del directorio estándar'
  END as Validacion
FROM Invt.Tb_Productos
WHERE Producto_ImagenRuta IS NOT NULL
ORDER BY 
    CASE 
        WHEN Producto_ImagenRuta LIKE 'C:\ImagenesDB\PRD-%.png' THEN 1
        WHEN Producto_ImagenRuta LIKE 'C:\ImagenesDB\%' THEN 2
        ELSE 3
    END;

-- ? 5. Productos con stock e imagen para verificar el sistema completo
PRINT '=== Productos con stock e imagen ==='
SELECT 
    P.Producto_Codigo,
    P.Producto_Nombre,
    P.Producto_ImagenRuta,
    ISNULL(SUM(I.Cantidad_Disponible), 0) AS Stock_Total,
    COUNT(I.Inventario_Id) as RegistrosInventario
FROM Invt.Tb_Productos P
LEFT JOIN Invt.Tb_Inventario I ON P.Producto_Id = I.Producto_Id
WHERE P.Producto_ImagenRuta IS NOT NULL
GROUP BY P.Producto_Codigo, P.Producto_Nombre, P.Producto_ImagenRuta
ORDER BY Stock_Total DESC;

PRINT '=== Script de verificación completado ==='