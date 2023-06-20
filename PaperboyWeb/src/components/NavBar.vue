<template>
  <div>
    <v-app-bar app color="primary" dark>
      <v-app-bar-nav-icon @click="drawer = !drawer" class="d-sm-none"></v-app-bar-nav-icon>
    
      <v-toolbar-title class="text-h6">Paperboy</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn @click="drawer = !drawer" to="/" class="d-none d-sm-flex">Home</v-btn>
      <v-btn @click="drawer = !drawer" to="/dashboard" class="d-none d-sm-flex">Dashboard</v-btn>
      <v-btn @click="isDialogOpen = true" class="d-none d-sm-flex">Create</v-btn>
    </v-app-bar>
    <v-navigation-drawer v-model="drawer" absolute temporary class="d-sm-none background">
      <v-list>
        <router-link to="/">
          <v-list-item>Home</v-list-item>
        </router-link>
        <router-link to="/dashboard">
          <v-list-item>Dashboard</v-list-item>
        </router-link>
        <v-list-item @click="isDialogOpen = true">Create</v-list-item>
      </v-list>
    </v-navigation-drawer>
    
    <!-- BotCreationDialog component -->
    <BotCreationDialog v-model:dialog="isDialogOpen" />

  </div>
</template>

<script lang="ts">
import { ref } from 'vue';
import BotCreationDialog from '@/components/BotCreationDialog.vue'; // Make sure to import BotCreationDialog component

export default {
  name: 'NavBar',
  components: {
    BotCreationDialog
  },
  setup() {
    const drawer = ref(false);
    const isDialogOpen = ref(false);
    return { drawer, isDialogOpen };
  },
};
</script>

<style scoped>
.background {
  background-color: #3B297Aff;
}
</style>
