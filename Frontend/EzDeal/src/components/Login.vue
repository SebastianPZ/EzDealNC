<template>
  <v-app id="login">
    <div id="formulario">
        <v-form>
          <div class="Titulo">Inicio de Sesion</div>
          <v-text-field name="name" label="Usuario" placeholder="Usuario" id="id"></v-text-field>
          <v-text-field type="password" placeholder="Contraseña" label="Contraseña"></v-text-field>
          <div class="Boton">
            <v-btn color="success" block>Inciar Sesion</v-btn>
          </div>
          <div class="Boton">
            <v-btn color="blue"   href="./registro" block>Registro</v-btn>
          </div>
        </v-form>
    </div>>
  </v-app>
</template>

<style>
#formulario {
  background-color: aqua;
  width: 30%;
  height: 40%;
  padding: 15px;
  display: block;
  margin: auto;
    

}
.Boton {
  position: relative;
  text-align: center;
  display: block;
}
.Titulo {
  font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
  font-size: 25px;
  text-align: center;
  font-weight: bold;
}
#login {
    background-image: url("../Resources/fondo.png");
    background-size: 100% 100%;
}
</style>





<script>
export default {
    data()
    {

    },
};
</script>