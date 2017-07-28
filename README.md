# IntNovAction.Utils.A3Exporter
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Utilidad para extraer las líneas utilizadas en el fichero de A3 para facturas y cuentas de proveedores
```c#
var exporter = new A3Exporter();
var results = exporter.ExportarFactura(factura);
var strResult = exporter.ExportarCuentaProveedor(cuentaProveedor);
```

## Exportar factura
Para exportar una factura se ha de configurar la entidad Factura, a la que se le añaden a su vez entidades de tipo LineaFactura. Los cálculos de importes, número de línea de factura, etc. se hacen automáticamente al ir añadiendo las líneas a la factura.
El exportador devuelve como resultado una lista de cadenas que corresponden con las líneas que hay que introducir en el fichero de A3 para contabilizar esa factura.

```c#
var factura = new Factura("2017/1002")
{
    CodigoEmpresa = 135,
    Fecha = new DateTime(2017, 4, 26),
    Cuenta = "430010370000",
    DescripcionCuenta = "Test Nombre cuenta",
    TipoFactura = TipoFactura.Ventas,
    DescripcionApunte = "Factura: 2017/1002",
    Importe = 4867.23M
};

var linea1 = new LineaFactura
{
    CodigoEmpresa = 135,
    Fecha = new DateTime(2017, 4, 26),
    Cuenta = "705100020000",
    DescripcionCuenta = "SERVICIOS JURIDICOS TEST",
    TipoImporte = TipoImporte.Cargo,
    DescripcionApunte = "(HN)Factura: 2017/1002",
    BaseImponible = 4022.5M,
    PorcentajeIVA = 21,
    TipoImpreso = TipoImpreso.Impreso_347
};

factura.AddLineaFactura(linea1);
var exporter = new A3Exporter();
var results = exporter.ExportarFactura(factura);
```

## Exportar datos de proveedor
Para exportar los datos de proveedor se ha de configurar la entidad CuentaProveedor.
El exportador devuelve la cadena correspondiente a la línea que hay que introducir en el fichero de A3 para que añada/modifique los datos del proveedor.

```c#
var cuentaProveedor = new CuentaProveedor
{
    CodigoEmpresa = 135,
    Fecha = new DateTime(2017, 01, 01),
    Cuenta = "430010010000",
    DescripcionCuenta = "DESCRIPCION CUENTA PROVEED",
    ActualizarSaldoInicial = false,
    NIF = "B12x52671",
    ViaPublica = "Direaccion test 132, plaza 123",
    Municipio = "MUNIC",
    CodigoPostal = "32619",
    Provincia = "Ourense",
    Telefono = "988888888",
    Fax = "988777777"
};

var exporter = new A3Exporter();
var strResult = exporter.ExportarCuentaProveedor(cuentaProveedor);            
```
