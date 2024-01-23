CREATE TABLE `Clientes` (
  `ID_Cliente` int NOT NULL,
  `Nombre` varchar(32) NOT NULL,
  `Apellido` varchar(32) NOT NULL,
  `Email` varchar(32) NOT NULL,
  `Telefono` varchar(12) NOT NULL,
  `Direccion` varchar(128) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Clientes`
--

INSERT INTO `Clientes` (`ID_Cliente`, `Nombre`, `Apellido`, `Email`, `Telefono`, `Direccion`) VALUES
(1, 'omar', 'string', 'string', 'string', 'string'),
(4, 'funciona', ':)', 'string', 'string', 'string');

-- --------------------------------------------------------

--
-- Table structure for table `DetallePedidos`
--

CREATE TABLE `DetallePedidos` (
  `ID_DetallePedido` int NOT NULL,
  `ID_Pedido` int NOT NULL,
  `ID_Producto` int NOT NULL,
  `Cantidad` int NOT NULL,
  `Subtotal` decimal(11,2) NOT NULL,
  `FechaCreacion` date NOT NULL,
  `FechaModificacion` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Empleados`
--

CREATE TABLE `Empleados` (
  `ID_Empleado` int NOT NULL,
  `Nombre` varchar(32) NOT NULL,
  `Apellido` varchar(32) NOT NULL,
  `Cargo` varchar(64) NOT NULL,
  `Salario` decimal(11,2) NOT NULL,
  `FechaEntrada` date NOT NULL,
  `FechaSalida` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Empleados`
--

INSERT INTO `Empleados` (`ID_Empleado`, `Nombre`, `Apellido`, `Cargo`, `Salario`, `FechaEntrada`, `FechaSalida`) VALUES
(1, 'zas', 'zas', 'zas', '0.00', '2023-12-04', '2023-12-04');

-- --------------------------------------------------------

--
-- Table structure for table `Pedidos`
--

CREATE TABLE `Pedidos` (
  `ID_Pedido` int NOT NULL,
  `ID_Cliente` int NOT NULL,
  `Fecha` date NOT NULL,
  `Total` decimal(11,2) NOT NULL,
  `Enviado` tinyint NOT NULL DEFAULT '0',
  `MetodoPago` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Pedidos`
--

INSERT INTO `Pedidos` (`ID_Pedido`, `ID_Cliente`, `Fecha`, `Total`, `Enviado`, `MetodoPago`) VALUES
(4, 1, '2023-12-04', '0.00', 1, '0');

-- --------------------------------------------------------

--
-- Table structure for table `Productos`
--

CREATE TABLE `Productos` (
  `ID_Producto` int NOT NULL,
  `Nombre` varchar(32) NOT NULL,
  `Descripcion` varchar(128) NOT NULL,
  `Precio` decimal(11,2) NOT NULL,
  `Stock` int NOT NULL,
  `Imagen` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Productos`
--

INSERT INTO `Productos` (`ID_Producto`, `Nombre`, `Descripcion`, `Precio`, `Stock`, `Imagen`) VALUES
(1, 'Omar', 'no trajo pa tomar', '10.00', 0, 'imagenpng');

-- --------------------------------------------------------

--
-- Table structure for table `RegistroVentas`
--

CREATE TABLE `RegistroVentas` (
  `ID_RegistroVentas` int NOT NULL,
  `ID_Empleado` int NOT NULL,
  `Fecha` date NOT NULL,
  `TotalVentas` int NOT NULL,
  `TotalCostos` decimal(11,2) NOT NULL,
  `TotalImpuestos` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `RegistroVentas`
--

INSERT INTO `RegistroVentas` (`ID_RegistroVentas`, `ID_Empleado`, `Fecha`, `TotalVentas`, `TotalCostos`, `TotalImpuestos`) VALUES
(4, 1, '2023-12-05', 0, '0.00', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Clientes`
--
ALTER TABLE `Clientes`
  ADD PRIMARY KEY (`ID_Cliente`);

--
-- Indexes for table `DetallePedidos`
--
ALTER TABLE `DetallePedidos`
  ADD PRIMARY KEY (`ID_DetallePedido`),
  ADD KEY `FK_ID_Pedido` (`ID_Pedido`),
  ADD KEY `FK_ID_Producto` (`ID_Producto`);

--
-- Indexes for table `Empleados`
--
ALTER TABLE `Empleados`
  ADD PRIMARY KEY (`ID_Empleado`);

--
-- Indexes for table `Pedidos`
--
ALTER TABLE `Pedidos`
  ADD PRIMARY KEY (`ID_Pedido`),
  ADD KEY `FK_ID_Cliente` (`ID_Cliente`);

--
-- Indexes for table `Productos`
--
ALTER TABLE `Productos`
  ADD PRIMARY KEY (`ID_Producto`);

--
-- Indexes for table `RegistroVentas`
--
ALTER TABLE `RegistroVentas`
  ADD PRIMARY KEY (`ID_RegistroVentas`),
  ADD KEY `FK_ID_Empleado` (`ID_Empleado`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Clientes`
--
ALTER TABLE `Clientes`
  MODIFY `ID_Cliente` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `DetallePedidos`
--
ALTER TABLE `DetallePedidos`
  MODIFY `ID_DetallePedido` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `Empleados`
--
ALTER TABLE `Empleados`
  MODIFY `ID_Empleado` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `Pedidos`
--
ALTER TABLE `Pedidos`
  MODIFY `ID_Pedido` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `Productos`
--
ALTER TABLE `Productos`
  MODIFY `ID_Producto` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `RegistroVentas`
--
ALTER TABLE `RegistroVentas`
  MODIFY `ID_RegistroVentas` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `DetallePedidos`
--
ALTER TABLE `DetallePedidos`
  ADD CONSTRAINT `FK_ID_Pedido` FOREIGN KEY (`ID_Pedido`) REFERENCES `Pedidos` (`ID_Pedido`),
  ADD CONSTRAINT `FK_ID_Producto` FOREIGN KEY (`ID_Producto`) REFERENCES `Productos` (`ID_Producto`);

--
-- Constraints for table `Pedidos`
--
ALTER TABLE `Pedidos`
  ADD CONSTRAINT `FK_ID_Cliente` FOREIGN KEY (`ID_Cliente`) REFERENCES `Clientes` (`ID_Cliente`);

--
-- Constraints for table `RegistroVentas`
--
ALTER TABLE `RegistroVentas`
  ADD CONSTRAINT `FK_ID_Empleado` FOREIGN KEY (`ID_Empleado`) REFERENCES `Empleados` (`ID_Empleado`);
COMMIT;
