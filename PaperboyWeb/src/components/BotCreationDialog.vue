<template>
  <v-dialog v-model="internalDialog" persistent max-width="600px">
    <v-card color="#4D0775" >
      <v-card-title class="text-overline">Create a Bot</v-card-title>
      <v-card-text class="dark-text">
        <v-text-field variant="outlined" v-model="bot.name" label="New Bot Name" density="compact"></v-text-field>
        <v-text-field class="dark-text" variant="outlined" v-model="bot.description" label="a simple description / detail" density="compact"></v-text-field>
        <v-text-field class="dark-text" variant="outlined" v-model="bot.token1" label="Primary Token - ex. MATIC" density="compact"></v-text-field>
        <v-text-field class="dark-text" variant="outlined" v-model="bot.token2" label="Currency Token - ex. USDT" density="compact"></v-text-field>
        <v-textarea class="dark-text" variant="outlined" v-model="webhookData" label="Webhook Data" :readonly="!webhookGenerated"></v-textarea>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="primary" @click="closeDialog">Close</v-btn>
        <v-btn color="primary" @click="createBot">Create</v-btn>
      </v-card-actions>
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

    const webhookData = ref('');
    const webhookGenerated = ref(false);

    const closeDialog = () => {
      internalDialog.value = false;
    };

    const createBot = async () => {
      const newBotData = await apiService.CreateNewBot(bot.value);
      webhookData.value = JSON.stringify(newBotData);
      webhookGenerated.value = true;
    };

    return { internalDialog, bot, createBot, closeDialog, webhookData, webhookGenerated };
  },
});
</script>

