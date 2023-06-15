<template>
            <v-row >
                <v-col cols="auto">
                    <v-avatar size="30">
                        <v-img src="https://s2.coinmarketcap.com/static/img/coins/64x64/3890.png"></v-img>
                    </v-avatar>
                </v-col>
                <v-col cols="auto">
                    <v-card-title class="text pa-0">MATIC / USDT</v-card-title>
                </v-col>
                <v-col cols="auto">
                    <v-card-title class="text pa-0">
                        <transition name="flash" mode="out-in">
                            <div :key="tokenPrice" :class="priceChangeClass">${{ tokenPrice }}</div>
                        </transition>
                    </v-card-title>
                </v-col>
            </v-row>
</template>

<script lang="ts">
import { ref, onMounted, onUnmounted} from 'vue';
import apiService from '@/services/apiService';

export default {
  name: 'TokenDataCard',
  emits: ['update-token-price'], // Declare the custom event

  setup(_, { emit }) { // Add the `emit` function to the setup parameters
    const tokenPrice = ref(0);
    const priceChangeClass = ref('default-color');

    const fetchTokenPrice = async () => {
      const response = await apiService.GetTokenPrice("MATIC-USDT");
      const newPrice = response.lastPrice;

      if (newPrice > tokenPrice.value) {
        priceChangeClass.value = 'price-up';
      } else if (newPrice < tokenPrice.value) {
        priceChangeClass.value = 'price-down';
      }
      tokenPrice.value = newPrice;
      emit('update-token-price', newPrice); // Emit the custom event

      // Reset color after 0.5 seconds
      setTimeout(() => {
        priceChangeClass.value = 'default-color';
      }, 300);
    };

    let intervalId: number | undefined;
    onMounted(() => {
      fetchTokenPrice();
      intervalId = setInterval(fetchTokenPrice, 2000); // Fetch price every 3 seconds
    });

    onUnmounted(() => {
      clearInterval(intervalId); // Clear interval when component is unmounted
    });

    return { tokenPrice, priceChangeClass };
  },
  computed: {
    percentChange() {
      // calculate total gains/losses here
      return 0
    },
  },
}
</script>


<style>
.price-up {
  color: #28E7ABff;
  transition: color 0.2s;
}

.price-down {
  color: #E26D0D;
  transition: color 0.2s;
}

.flash-enter-active, .flash-leave-active {
  transition: opacity 0s;
}

.flash-enter, .flash-leave-to {
  opacity: 0;
}

div {
  color: white;
  transition: color 0.3s;
}
</style>
