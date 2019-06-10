<template>
  <v-layout align-start>
    <v-flex>
      <v-toolbar flat color="white">
        <v-toolbar-title>Anuncios</v-toolbar-title>
        <v-divider class="mx-2" inset vertical></v-divider>
        <v-spacer></v-spacer>
        <v-text-field
          class="text-xs-center"
          v-model="search"
          append-icon="search"
          label="Búsqueda"
          single-line
          hide-details
        ></v-text-field>
        <v-spacer></v-spacer>
        <v-dialog v-model="dialog" max-width="500px">
          <v-btn slot="activator" color="primary" dark class="mb-2">Nuevo</v-btn>
          <v-card>
            <v-card-title>
              <span class="headline">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <v-container grid-list-md>
                <v-layout wrap>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="anunciante_id" label="Anunciante_ID"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="titulo" label="Titulo"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="descripcion" label="Descripcion"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="costo_servicio" label="Costo del Servicio"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="servicio_id" label="Servicio"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="esta_habilitado" label="Esta_habilitado"></v-text-field>
                  </v-flex>
                  <v-flex xs12 sm12 md12>
                    <v-text-field v-model="valoracion" label="Valoracion"></v-text-field>
                  </v-flex>
                </v-layout>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" flat @click.native="close">Cancelar</v-btn>
              <v-btn color="blue darken-1" flat @click.native="guardar">Guardar</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
      <v-data-table :headers="headers" :items="anuncios" :search="search" class="elevation-1">
        <template slot="items" slot-scope="props">
          <td class="justify-center layout px-0">
            <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          
          </td>
          <td>{{ props.item.anunciante_id }}</td>
          <td>{{ props.item.titulo }}</td>
          <td>{{ props.item.descripcion }}</td>
          <td>{{ props.item.costo_servicio }}</td>
          <td>{{ props.item.servicio_id }}</td>
          <td>{{ props.item.esta_habilitado }}</td>
          <td>{{ props.item.valoracion }}</td>
        </template>
        <template slot="no-data">
          <v-btn color="primary" @click="listar">Resetear</v-btn>
        </template>
      </v-data-table>
    </v-flex>
  </v-layout>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      anuncios: [],
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Anunciante_ID", value: "anunciante_id"},
        { text: "Titulo", value: "titulo"},
        { text: "Descripcion", value: "descripcion"},
        { text: "Costo_Servicio", value: "costo_servicio"},
        { text: "Servicio_ID", value: "servicio_id"},
        { text: "Esta_habilitado", value: "esta_habilitado"},
        { text: "Valoracion", value: "valoracion" }
      ],
      search: "",
      editedIndex: -1,

      //Model
      id: "",
      anunciante_id: "",
      titulo: "",
      descripcion: "",
      costo_servicio : "",
      servicio_id : "",
      esta_habilitado : "",
      valoracion: "",
      servicio : { nombre=""}



    },
    {
      
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Anuncio" : "Actualizar Anuncio";
    }
  },

  watch: {
    dialog(val) {
      val || this.close();
    }
  },

  created() {
    this.listar();
  },
  methods: {
    listar() {
      let me = this;
      axios.get("api/anuncio").then(function(response) {
          //console.log(response);
          me.anuncios = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    editItem(item) {
      this.id = item.id;
      this.anunciante_id = item.anunciante_id;
      this.titulo = item.titulo;
      this.descripcion = item.descripcion;
      this.costo_servicio = item.costo_servicio;
      this.servicio_id = item.servicio_id;
      this.esta_habilitado = item.esta_habilitado;
      this.valoracion = item.valoracion;

      this.editedIndex = 1;
      this.dialog = true;
    },

  

    close() {
      this.dialog = false;
    },
    limpiar() {
      this.id = "";
      this.anunciante_id = "";
      this.titulo = "";
      this.descripcion = "";
      this.costo_servicio = "";
      this.servicio_id ="";
      this.esta_habilitado = "";
      this.valoracion = "";

    },
    guardar() {
      if (this.editedIndex > -1) {
        //Código para editar

        let me = this;
        axios 
          .put("api/anuncio", {
            id: me.id,
            anunciante_id : me.anunciante_id,
            titulo : me.titulo,
            descripcion : me.descripcion,
            costo_servicio : me.costo_servicio,
            servicio_id : me.servicio_id,
            esta_habilitado : me.esta_habilitado,
            valoracion : me.valoracion
          })
          .then(function(response) {
            me.close();
            me.listar();
            me.limpiar();
          })
          .catch(function(error) {
            console.log(error);
          });
      } else {
        //Código para guardar
        let me = this;
        axios
          .post("api/anuncio", {
            anunciante_id : me.anunciante_id,
            titulo : me.titulo,
            descripcion: me.descripcion,
            costo_servicio : me.costo_servicio,
            servicio_id : me.servicio_id,
            esta_habilitado : me.esta_habilitado,
            valoracion : me.valoracion
          })
          .then(function(response) {
            me.close();
            me.listar();
            me.limpiar();
          })
          .catch(function(error) {
            console.log(error);
          });
      }
    }
  }
};
</script>
