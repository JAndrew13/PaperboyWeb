<template>
  <v-app>
    <v-app-bar :elevation="3" class="custom-navbar">
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>

      <router-link to="/" class="navbar-title">
        <v-icon class="mr-2" color="white">mdi-alpha-p-box</v-icon>
        Paperboy
      </router-link>

      <v-spacer></v-spacer>

      <v-menu offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-btn icon v-bind="attrs" v-on="on">
            <v-icon color="white">mdi-hamburger</v-icon>
          </v-btn>
        </template>
        <v-list>
          <v-list-item @click="$router.push('/')">
            <v-list-item-title>Home</v-list-item-title>
          </v-list-item>
          <v-list-item @click="$router.push('/about')">
            <v-list-item-title>About</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
    </v-app-bar>

    <v-main>
      <router-view/>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'App',
  data() {
    return {
      drawer: false
    }
  },
})
</script>

<style>
.custom-navbar {
  background-color: #008080;
}

.navbar-title {
  color: white !important;
  text-decoration: none;
  display: flex;
  align-items: center;
}

body, html, #app, #app > div {
  height: 100%;
}
</style>
