<template>
  <v-dialog v-model="internalDialog" persistent max-width="600px">
    <v-card color="#4D0775" >
      <v-card-title>
        <v-row cols="auto">
        <v-card-text class="text-overline">Create a Bot</v-card-text>
        <v-btn color="primary" class="ma-4" @click="closeDialog">Close</v-btn>
      </v-row>
      </v-card-title>
      <v-card-text class="dark-text">
        <v-text-field variant="outlined" v-model="bot.name" label="New Bot Name" density="compact"></v-text-field>
        <v-text-field class="dark-text" variant="outlined" v-model="bot.description" label="A simple description / detail" density="compact"></v-text-field>
        <v-text-field class="dark-text" variant="outlined" v-model="bot.token1" label="Primary Token - ex. MATIC" density="compact"></v-text-field>
        <v-text-field class="dark-text" variant="outlined" v-model="bot.token2" label="Currency Token - ex. USDT" density="compact"></v-text-field>
        <v-card-actions>
          <v-btn  class="mx-auto" color="primary" @click="createBot">Create</v-btn>
        </v-card-actions>
      </v-card-text>
      <v-card-text>
        <v-textarea class="dark-text" variant="outlined" v-model="webhookDataBuy" label="Buy Alert Code" :readonly="!webhookGenerated"></v-textarea>
      </v-card-text>  

      <v-card-text>
        <v-textarea class="dark-text" variant="outlined" v-model="webhookDataSell" label="Sell Alert Code" :readonly="!webhookGenerated"></v-textarea>
      </v-card-text>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import apiService from '@/services/apiService';
import { defineComponent, ref, watch, toRefs } from 'vue';

interface BotData {
  name: string;
  description: string;
  token1: string;
  token2: string;
}

export default defineComponent({
  name: 'BotCreationDialog',
  props: {
    dialog: {
      type: Boolean,
      default: false,
    },
  },
  emits: ['update:dialog'],
  setup(props, { emit }) {
    const { dialog } = toRefs(props);
    const internalDialog = ref(dialog.value);

    watch(internalDialog, (newValue) => {
      emit('update:dialog', newValue);
    });

    watch(dialog, (newValue) => {
      internalDialog.value = newValue;
    });

    const bot = ref<BotData>({
      name: '',
      description: '',
      token1: '',
      token2: '',
    });

    const webhookDataBuy = ref('');
    const webhookDataSell = ref('');
    const webhookIsGenerated = ref(false);

    const closeDialog = () => {
      internalDialog.value = false;
    };

    const createBot = async () => {
      const newBotData = await apiService.CreateNewBot(
        bot.value.name, 
        bot.value.description,
        bot.value.token1,
        bot.value.token2);

      const sellCode = newBotData
      sellCode.action = "SELL"
      webhookDataSell.value = JSON.stringify(sellCode);

      const buyCode = newBotData
      buyCode.action = "BUY"
      webhookDataBuy.value = JSON.stringify(buyCode);



      webhookIsGenerated.value = true;
    };

    return { 
      internalDialog, 
      bot, 
      createBot, 
      closeDialog, 
      webhookDataBuy, 
      webhookDataSell, 
      webhookGenerated: webhookIsGenerated };
  },
});
</script>

