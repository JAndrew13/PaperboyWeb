<!-- components/Navbar.vue -->
<template>
  <v-app-bar app class="custom-navbar">
    <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
    <v-toolbar-title>Paperboy</v-toolbar-title>
    <v-spacer></v-spacer>
    <v-btn text="Home">
      <router-link to="/" class="text-decoration-none text--white">Home</router-link>
    </v-btn>
    <v-btn text="About">
      <router-link to="/about" class="text-decoration-none text--white">About</router-link>
    </v-btn>
  </v-app-bar>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'NavBar',
  data() {
    return {
      drawer: false
    }
  }
})
</script>

<style scoped>
.custom-navbar {
  background-color: #008080;
}

.text--white {
  color: white !important;
}
</style>
