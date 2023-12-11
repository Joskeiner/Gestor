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


//----- Lista de productos ---------

$(document).ready(function () {

    fetch("/Categoria/Lista")

        .then(response => {
            return response.ok ? response.json() : Promise.reject(response);
        })

        .then(responseJson => {
            if (responseJson.data.length > 0) {
                responseJson.data.forEach((item) => {
                    $("#cboCategoria").append($("<option>").val(item.CategoriaId).text(item.descripcion))
                })
            }
        })

    tabalaData = $("#tbdata").DataTable({
        responsive: true,

        "ajax": {
            "url": "/Producto/Lista",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "Id", "visible": false, "searchable": false },
            {
                "data": "urlImagen", render: function (data) {
                    return `<img style="height:60px" src=${data}/ class="rounded mx-auto d-block"> `
                }
            },
            { "data": "codigoBarra" },
            { "data": "marca" },
            { "data": "descripcion" },
            { "data": "nombreCategoria" },
            { "data": "stock" },
            { "data": "precio" },
            {
                "data": "esActivo", render: function (data) {
                    if (data == 1) {
                        return '<span class = "badge badge-info">Activo</span>';
                    } else {
                        return '<span class = "badge badge-danger">No Activo</span>';
                    }
                }
            },
            {
                "dafaultContent": '<button class="btn btn-primary btn-editar btn-sm mr-2"><i class"fas fa-pancil-alt"></i></button>' +
                    '<button class="btn btn-primary btn-editar btn-sm mr-2"><i class"fas fa-pancil-alt"></i></button>',
                "orderable": false,
                "searchable": false,
                "width": "90px"
            }
        ],
        order: [[0, "desc"]],
        dom: "Bfrtrip",
        buttons: [
            {
                text: 'Exportar Execel',
                extend: 'execlHtml5',
                title: '',
                filename: 'reporte Productos',
                exportOptions: {
                    columns: [2, 3, 4, 5, 6, 7]
                }
            }, 'pageLength'
        ],
        languaje: {

            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
    });
});