<template>
    <v-app-bar app color="primary" dark>
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
      <v-icon>mdi-finance</v-icon>
      <v-toolbar-title class="text-h6">Paperboy</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn to="/">Home</v-btn>
      <v-btn to="/dashboard">Dashboard</v-btn>
      <v-btn @click="$emit('open-dialog')">Create</v-btn>
    </v-app-bar>
  </template>
  
  <script lang="ts">
  import { ref } from 'vue';
  
  export default {
    name: 'NavBar',
    setup() {
      const drawer = ref(false);
      return { drawer };
    },
  };
  </script>
  