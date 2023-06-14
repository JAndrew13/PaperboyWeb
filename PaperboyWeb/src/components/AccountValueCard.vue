<template>
  <v-card fluid max-width="350" pa-2>
    <v-card-item>
      <div class="text-overline">Total Account Value</div>
      <v-row cols="auto">
        <v-col sm="12" md="6" lg="4">
          <div class="text-right text-h3 mt-2 font-weight-bold">{{accountValue}}</div>
        </v-col>

        <v-col >
          <v-list>
            <v-list-item class="pa-0">
                <v-list-item-title class="text-left font-weight-medium">USDT </v-list-item-title>
                <v-list-item-subtitle class="text-left text-caption">≈ ${{accountValue}}</v-list-item-subtitle>
            </v-list-item>
          </v-list>
        </v-col>
      </v-row>
      <v-row cols="auto">
        <v-col>
          <TokenDataCard @update-token-price="$emit('update-token-price', $event)"></TokenDataCard>
      </v-col>
      </v-row>
    </v-card-item>
    <v-card-item>
    <v-btn @click="refreshAccountValue">Refresh Account Value</v-btn>
    </v-card-item>
  </v-card>
  
</template>

<script lang="ts">
import { ref, type PropType, } from 'vue';
import TokenDataCard from '@/components/TokenDataCard.vue';
import { Account } from '@/scripts/account';
import useAccountValue from '../composable/accountValue'


export default {
  name: "AccountValueCard",
  props: {
      accounts: {
          type: Array as PropType<Account[]>,
          required: true,
      }
  },
  components: { TokenDataCard},
  setup() { 
      const tokenPrice = ref(0); // ref to store the token price
      const updateTokenPrice = (newPrice: number) => {
          tokenPrice.value = newPrice; // Update the token price
      };

      const { accountValue, refreshAccountValue } = useAccountValue()

      return {tokenPrice, updateTokenPrice, accountValue, refreshAccountValue,};
  }
}

</script> 
