<template>
    <div>
      <v-app-bar app color="primary">
        <v-toolbar-title>Paperboy</v-toolbar-title>
      </v-app-bar>
      <v-main>
        <v-container>
          <v-row>
            <v-col cols="12">
              <h1>Welcome to Paperboy</h1>
              <p>Your personal algo trading bot.</p>
            </v-col>
          </v-row>
        </v-container>
      </v-main>
    </div>
  </template>
  
  <script lang="ts">
  import { defineComponent } from 'vue';
  import { Bot } from '../scripts/bot';
  import { Order } from '../scripts/order';
  import sampleData from '@/services/sampleData';
  import BotCard1 from '../components/BotCard1.vue';
  
  export default defineComponent({
    name: 'LandingPage',
  });
  </script>
  
  <style scoped>
  /* Add any styles specific to the landing page here */
  </style>
  