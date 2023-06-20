<template>
  <v-img :src="bgImage" class="background-image">
  <div>
    <NavBar @open-dialog="dialog = true" />
    
      <v-main>
        <v-container fluid>
          <v-container class="fill-height d-flex align-center">
            <v-row>
              <v-col class="text-center">
                <div class="title-container"> 
                  <h1 class="white--text mb-4 title-text">Paperboy.</h1>
                  <h3 class="font-weight-medium white--text mb-2 subtitle">Your personal algo trading bot.</h3>
                </div>
              </v-col>
            </v-row>
          </v-container>
        </v-container>
      </v-main>
      <BotCreationDialog v-model="dialog" />
  
  </div>
</v-img>
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
  .title-text {
    font-family: 'Signika', sans-serif;
    font-size: 5rem;
    font-weight: 500;
  }

  .subtitle {
    font-family: 'Lilita One', cursive;
    font-size: 1.5rem;
    font-weight: 500;
  }

  .background-image {
    background-size: cover; 
    background-color:aqua
  }

  /* Add media query for mobile screens */
  @media only screen and (max-width: 600px) {
    .title-container {
      margin-top: 300px; /* Adjust this value to position text further down */
    }
  }

</style>
