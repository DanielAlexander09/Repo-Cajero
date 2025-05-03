# Cajero Automático - Módulo de Retiro de Dinero

Este proyecto es una simulación de un cajero automático enfocado únicamente en el **módulo de retiro de dinero**. El sistema permite al usuario retirar una cantidad de dinero específica según un **modo de dispensación configurado previamente**.

## Características

- Selección de **modo de dispensación** mediante una interfaz con menú y formulario.
- Tres modos disponibles:
  1. **Solo billetes de 200 y 1000.**
  2. **Solo billetes de 100 y 500.**
  3. **Modo eficiente (por defecto):** entrega la menor cantidad de billetes utilizando denominaciones de 100, 200, 500 y 1000.
- Validación del monto ingresado:
  - Debe ser un número entero.
  - Solo múltiplos de 100.
  - Debe ser compatible con el modo seleccionado.
- Resultado del retiro: se muestra la cantidad y tipo de billetes entregados.
- Persistencia de la configuración del modo de dispensación.

## Estructura del Proyecto

- **Controladores:** Lógica del retiro y gestión de la configuración del modo.
- **Vistas:**
  - Menú principal.
  - Pantalla de selección del modo de dispensación.
  - Formulario para el retiro de dinero.
  - Resultados del retiro.

## Modo de Dispensación

| Modo                     | Billetes utilizados                  | Ejemplo (Retiro 1200)                   |
|--------------------------|--------------------------------------|-----------------------------------------|
| Solo 200 y 1000          | 200, 1000                            | 1 x 1000, 1 x 200                        |
| Solo 100 y 500           | 100, 500                             | 2 x 500, 2 x 100                         |
| Eficiente (por defecto)  | 100, 200, 500, 1000 (menor cantidad) | 1 x 1000, 1 x 200                        |

## Requisitos

- Navegador moderno (para interfaz web).
- Backend en el lenguaje/framework elegido (por ejemplo, PHP, Laravel, Node.js, etc.).
- Persistencia de datos (puede ser archivo local o base de datos).

## Instalación y Ejecución

1. Clona este repositorio:
   ```bash
   git clone https://github.com/usuario/cajero-retiro.git
   cd cajero-retiro
