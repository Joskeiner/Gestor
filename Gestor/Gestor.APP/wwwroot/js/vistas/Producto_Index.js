const MODELO_BASE = {
    Id: 0,
    codigoBarra: "",
    marca: "",
    descripcion: "",
    CategoriaId: 0,
    stock: 0,
    urlImagen: "",
    precio: 0,
    esActivo:1
}

let tabalaData;
let filaSeleccionada;

//----------- Modal Vacio ------------

function mostrarModal(modelo = MODELO_BASE) {
    $("#txtId").val(modelo.Id)
    $("#txtCodigoBarra").val(modelo.codigoBarra)
    $("#txtMarca").val(modelo.marca)
    $("#txtDescripcion").val(modelo.descripcion)
    $("#cboCategoria").val(modelo.CategoriaId == 0 ? $("#cboCategoria option:firts").val() : modelo.CategoriaId)
    $("#txtStock").val(modelo.stock)
    $("#txtPrecio").val(modelo.precio)
    $("#cboEstado").val(modelo.esActivo)
    $("#txtImagen").val("")
    $("#imgProducto").attr("src", modelo.urlImagen)


    $("#modalData").modal("show")

}



//------ Nuevo Productos -----------

$("#btnNuevo").click(function () {
    mostrarModal();
})