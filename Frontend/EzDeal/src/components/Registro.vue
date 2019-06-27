<template>
  <v-app id="Registro">
    
    <v-content grid-list-xs justify-center align-center>
      <h1 class="titulo">Registro</h1>
      <v-form ref="form" style="padding:60px" class="formulario" v-model="valid" lazy-validation>
        <v-layout xs11>
          <v-flex xs5>
            <v-text-field v-model="nombre" :rules="nameRules" label="Nombres" required></v-text-field>
          </v-flex>
          <v-flex xs2></v-flex>
          <v-flex xs5 justify-end>
            <v-text-field v-model="apellido" label="Apellidos" required></v-text-field>
          </v-flex>
        </v-layout>

        <v-text-field v-model="email" :rules="emailRules" label="E-mail" required></v-text-field>
        <v-text-field v-model="contraseña" type="password" label="Contraseña" required></v-text-field>
        <v-text-field v-model="url_contacto" label="URL_Contacto"></v-text-field>
        <v-text-field v-model="telefono" label="Telefono" required></v-text-field>
        <v-select
          v-model="selDistrito"
          :items="distritos"
          :rules="[v => !!v || 'Item is required']"
          label="Distrito"
          required
        ></v-select>
        <v-checkbox
          v-model="checkbox"
          :rules="[v => !!v || 'Debe estar de acuerdo para continuar']"
          label="De acuerdo con las politicas"
          required
        ></v-checkbox>
        <v-btn :disabled="!valid" color="success" block @click="guardar">Registrarse</v-btn>
      </v-form>
    </v-content>
  </v-app>
</template>

<style>
.formulario {
  margin: 60px;
  background-color: darkkhaki;
}
.titulo {
  position: relative;
  display: block;
  text-align: center;
  font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
  font-size: 50px;
}

#Registro {
  background-image: url("../Resources/fondo.png");
  background-size: 100% 100%;

}
</style>






<script>
import axios from "axios";
import router from "vue-router";
export default {
  data: () => ({
    valid: true,
    nombre: "",
    apellido: "",
    contraseña: "",
    url_contacto: null,
    telefono: "",
    distritos: [
      "Ancón",
      "Ate",
      "Barranco",
      "Bellavista",
      "Breña",
      "Callao",
      "Carabayllo",
      "Carmen de la Lengua",
      "Chaclacayo",
      "Chorrillos",
      "Cieneguilla",
      "Comas",
      "El Agustino",
      "Independencia",
      "Jesús María",
      "La Molina",
      "La Perla",
      "La Punta",
      "La Victoria",
      "Lima",
      "Lince",
      "Los Olivos",
      "Lurigancho",
      "Lurín",
      "Magdalena del Mar",
      "Mi Perú",
      "Miraflores",
      "Pachacámac",
      "Publo Libre",
      "Pucusana",
      "Puente Piedra",
      "Punta Hermosa",
      "Punta Negra",
      "Rímac",
      "San Bartolo",
      "San Borja",
      "San Isidro",
      "San Juan de Lurigancho",
      "San Juan de Miraflores",
      "San Luis",
      "San Martín de Porres",
      "San Miguel",
      "Santa Anita",
      "Santa María del Mar",
      "Santa Rosa",
      "Santiago de Surco",
      "Surquillo",
      "Ventanilla",
      "Villa El Salvador",
      "Villa María del Triunfo"
    ],

    nameRules: [
      v => !!v || "Name is required",
      v => (v && v.length <= 10) || "Name must be less than 10 characters"
    ],
    email: "",
    emailRules: [
      v => !!v || "E-mail is required",
      v => /.+@.+/.test(v) || "E-mail must be valid"
    ],
    selDistrito: null,
    items: ["Item 1", "Item 2", "Item 3", "Item 4"],
    checkbox: false
  }),

  methods: {
    validate() {
      if (this.$refs.form.validate()) {
        this.snackbar = true;
      }
    },
    reset() {
      this.$refs.form.reset();
    },
    redireccionar() {
      if (this.$refs.form.validate()) {
        this.$router.push("./login");
      }
    },

    guardar() {
      //Código para guardar
      let me = this;
      axios
        .post("api/usuario", {
          nombre: me.nombre,
          apellido: me.apellido,
          email: me.email,
          contraseña: me.contraseña,
          url_contacto: me.url_contacto,
          telefono: me.telefono,
          distrito: me.selDistrito
        })
        .then(function(response) {
          me.redireccionar();
        })
        .catch(function(error) {
          console.log(error);
        });
    }
  }
};
</script>