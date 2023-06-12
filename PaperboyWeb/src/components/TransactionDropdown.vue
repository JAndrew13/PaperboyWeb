<template>
  <div>
    <h2>Transactions</h2>
    <v-list v-if="orders && orders.length">
      <v-list-item v-for="(order, index) in orders" :key="index">
        <v-list-item-content>
          <div>Transaction ID: {{ order.id }}</div>
          <div>Amount: {{ order.amount }}</div>
          <!-- Add more transaction details as needed -->
        </v-list-item-content>
      </v-list-item>
    </v-list>
    <div v-else>No transactions found</div>
  </div>
</template>

<script lang="ts">
import { defineComponent, type PropType } from 'vue';

interface Order {
  id: string;
  amount: number;
  // Add more transaction properties as needed
}

export default defineComponent({
  name: 'TransactionDropdown',
  props: {
    orders: {
      type: Array as PropType<Order[]>,
      required: true,
    },
  },
});
</script>

<style scoped>
/* Add any styles specific to the transaction dropdown here */
</style>
