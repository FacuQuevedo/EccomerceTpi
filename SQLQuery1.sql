
-- Tabla: Rol
CREATE TABLE Rol (
    id_rol INT PRIMARY KEY NOT NULL,
    UserType NVARCHAR(50) NOT NULL
);



-- Tabla: Productos
CREATE TABLE Productos (
    id_producto INT PRIMARY KEY NOT NULL,
    producto NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(255),
    precio DECIMAL(10, 2) NOT NULL
);

-- Tabla: Variante
CREATE TABLE Variante (
    id_variante INT PRIMARY KEY NOT NULL,
    color NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(255) NOT NULL
);


-- Tabla: Users
CREATE TABLE Users (
    id_user INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    nombre NVARCHAR(100) NOT NULL,
    apellido NVARCHAR(100) NOT NULL,
    mail NVARCHAR(100) NOT NULL UNIQUE,
	clave NVARCHAR(50) NOT NULL,
    id_rol INT NOT NULL,
    FOREIGN KEY (id_rol) REFERENCES Rol(id_rol)
);


-- Tabla: Ventas
CREATE TABLE Ventas (
    id_venta INT PRIMARY KEY NOT NULL,
    fecha_venta DATE NOT NULL,
    id_user INT NOT NULL,
    FOREIGN KEY (id_user) REFERENCES Users(id_user)
);




-- Tabla: Envios
CREATE TABLE Envios (
    id_envio INT PRIMARY KEY NOT NULL,
    destino NVARCHAR(100) NOT NULL,
    estado_envio NVARCHAR(50) NOT NULL,
    id_producto INT NOT NULL,
    id_venta INT NOT NULL,
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto),
    FOREIGN KEY (id_venta) REFERENCES Ventas(id_venta)
);