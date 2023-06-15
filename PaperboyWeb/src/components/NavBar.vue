<template>
  <div>
    <v-app-bar app color="primary" dark>
      <v-app-bar-nav-icon @click="drawer = !drawer" class="d-sm-none"></v-app-bar-nav-icon>
      <v-icon>mdi-finance</v-icon>
      <v-toolbar-title class="text-h6">Paperboy</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn @click="drawer = !drawer" to="/" class="d-none d-sm-flex">Home</v-btn>
      <v-btn @click="drawer = !drawer" to="/dashboard" class="d-none d-sm-flex">Dashboard</v-btn>
      <v-btn @click="$emit('open-dialog')" class="d-none d-sm-flex">Create</v-btn>
    </v-app-bar>
    <v-navigation-drawer v-model="drawer" absolute temporary class="d-sm-none background">
      <v-list>
    <router-link to="/">
      <v-list-item>Home</v-list-item>
    </router-link>
    <router-link to="/dashboard">
      <v-list-item>Dashboard</v-list-item>
    </router-link>
    <v-list-item @click="$emit('open-dialog')">Create</v-list-item>
  </v-list>
    </v-navigation-drawer>
  </div>
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

<style scoped>
.background {
  background-color: #3B297Aff;
}
</style>