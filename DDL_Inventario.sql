create DataBase Laboratorio

Create table tipo_producto (
	id_producto Int not null Identity (1,1),
	categoria varchar(20) null,
	descripción varchar(20) null,
	constraint PK_tipo_producto Primary key clustered(id_producto)
	);

	Create table proveedor (
	id_proveedor Int not null Identity (1,1),
	nombre varchar(20) null,
	dirección varchar(20) null,
	telefono nchar(20) null,
	constraint PK_proveedor Primary key clustered(id_proveedor)
	);


	Create table producto(
	codigo Int not null Identity (1,1),
	nombre_producto varchar(20) null,
	tipo_producto int null,
	descripcion nchar(20) null,
	precio money null,
	cantidad_min int null,
	cantidad_max int null,
	proveedor int null,
	constraint PK_producto Primary key clustered(codigo),
	Constraint Fk_tipo_producto Foreign key(tipo_producto) references tipo_producto(id_producto),
	Constraint Fk_Proveedor Foreign key(proveedor) references proveedor(id_proveedor)
	);


	Create table detalle_factura(
	id_factura Int not null Identity (1,1),
	cantidad_detalle int,
	valor_unitrio int,
	numero_detalle int,
	constraint PK_Detalle_factura Primary key clustered(id_factura),
	Constraint Fk_Detalle_factura Foreign key(numero_detalle) references producto(codigo)
	);

	Create table ventas(
	id_venta Int not null Identity (1,1),
	tipo_venta  int,
	fecha date,
	detalle_factura int,
	constraint PK_venta Primary key clustered(id_venta),
	Constraint Fk_Ventas_Factura Foreign key(detalle_factura) references detalle_factura(id_factura)
	);

	Create table tipo_venta(
	id_tipo_venta Int not null Identity (1,1),
	categoria int,
	descripción varchar(20)null,
	constraint PK_tipo_venta Primary key clustered(id_tipo_venta),
	Constraint Fk_tipo_venta Foreign key(id_tipo_venta) references ventas(id_venta)
	);

	Create table cliente(
	id_cliente Int not null Identity (1,1),
	nombre varchar(20) null,
	apellido varchar(20) null,
	dirección varchar(20) null,
	telefono varchar(20) null,
	correo varchar(20) null,
	compra int,
	constraint PK_cliente Primary key clustered(id_cliente),
	Constraint Fk_Cliente Foreign key(compra) references ventas(id_venta)
	);