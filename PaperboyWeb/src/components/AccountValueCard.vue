<template>
    <v-card fluid max-width="350" pa-2>
      <v-card-item>
        <div class="text-overline">Total Account Value</div>
        <v-row>
          <v-col>
            <div class="text-h3 mt-2 font-weight-bold">103.49</div>
          </v-col>

          <v-col >
            <v-list>
              <v-list-item class="pa-0">
                  <v-list-item-title class="font-weight-medium">USDT </v-list-item-title>
                  <v-list-item-subtitle class="text-caption">≈ $103.49 USD</v-list-item-subtitle>
              </v-list-item>
            </v-list>
          </v-col>
        </v-row>
      </v-card-item>
    </v-card>
</template>

<script lang="ts">
export default {
  name: 'AccountValueCard',
  props: {
    accounts: {
      type: Array,
      required: true,
    }
  }
}
</script>