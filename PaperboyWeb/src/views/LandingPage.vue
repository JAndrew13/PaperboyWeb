<template>
  <div>
    <NavBar @open-dialog="dialog = true" />
    <v-img
          :src="bgImage"
        >
    <v-main>
      
      <v-container fluid>
        
          <v-container class="fill-height d-flex align-center">
            <v-row>
              <v-col class="text-center">
                <v-spacer></v-spacer>
                <h1 class="font-weight-bold white--text mb-4">Welcome to Paperboy</h1>
                <h3 class="font-weight-medium white--text mb-2">Your personal algo trading bot.</h3>
              </v-col>
            </v-row>
          </v-container>
        
      </v-container>
    
    </v-main>
    <BotCreationDialog v-model="dialog" />
  </v-img>
  </div>
</template>

<script lang="ts">
import { ref, computed } from 'vue';
import NavBar from '../components/NavBar.vue';
import BotCreationDialog from '../components/BotCreationDialog.vue';
import { useWindowSize } from '@vueuse/core';
import bgImageDesktop from '@/assets/bg2.jpg'; // Import the desktop image
import bgImageMobile from '@/assets/bg2.jpg'; // Import the mobile image

export default {
  name: 'LandingPage',
  components: {
    NavBar,
    BotCreationDialog,
  },
  setup() {
    const dialog = ref(false);
    const { width } = useWindowSize();

    const bgImage = computed(() => {
      // If the window width is less than or equal to 600px, return the mobile image
      // Otherwise, return the desktop image
      return width.value <= 600 ? bgImageMobile : bgImageDesktop;
    });

    return { dialog, bgImage };
  },
};
</script>

<style scoped>
/* Add any styles specific to the landing page here */
</style>
