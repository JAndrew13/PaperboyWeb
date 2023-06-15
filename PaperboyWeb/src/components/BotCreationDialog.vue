<template>
  <v-dialog  v-model="dialog" persistent max-width="600px">
    <v-card color="#F2EBBF" >
      <v-card-title class="text-overline dark-text">Create a Bot</v-card-title>
      <v-card-text class="dark-text">
        <v-text-field color="primary" class="dark-text text-black" v-model="bot.name" label="New Bot Name"></v-text-field>
        <v-text-field class="dark-text" v-model="bot.description" label="a simple description / detail"></v-text-field>
        <v-text-field class="dark-text" v-model="bot.token1" label="Primary Token - ex. MATIC"></v-text-field>
        <v-text-field class="dark-text" v-model="bot.token2" label="Currency Token - ex. USDT"></v-text-field>
        <v-textarea class="dark-text" v-model="webhookData" label="Webhook Data" :readonly="!webhookGenerated"></v-textarea>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="primary"  @click="closeDialog">Close</v-btn>
        <v-btn color="primary"  @click="createBot">Create</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>


<script lang="ts">
import apiService from '@/services/apiService';
import { defineComponent, ref } from 'vue';

interface BotData {
name: string;
description: string;
token1: string;
token2: string;
}

export default defineComponent({
name: 'BotCreationDialog',
setup() {
  const dialog = ref(false);
  const bot = ref<BotData>({
    name: '',
    description: '',
    token1: '',
    token2: '',
  });
  const webhookData = ref('');
  const webhookGenerated = ref(false);

  const closeDialog = () => {
    dialog.value = false;
  };

  const createBot = async () => {
    const newBotData = await apiService.CreateNewBot(bot.value);
    webhookData.value = JSON.stringify(newBotData);
    webhookGenerated.value = true;
  };

  return { dialog, bot, createBot, closeDialog, webhookData, webhookGenerated };
},
});
</script>
<style scoped>
.dark-text {
  color: darkslategray !important;
}
</style>

