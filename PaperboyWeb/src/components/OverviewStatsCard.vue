<template>

<v-card max-width="350">
    <v-table density="compact">
    <thead>
      <tr>
        <th class="text-left">
          <v-avatar size="24">
            <v-img src="https://s2.coinmarketcap.com/static/img/coins/64x64/3890.png"></v-img>
          </v-avatar>
        </th>
        <th class="text-left text-overline">Day</th>
        <th class="text-left text-overline">Week</th>
        <th class="text-left text-overline">Month</th>
      </tr>
    </thead>
    <tbody>
      <tr
        v-for="item in TimeFrames"
        :key="item.name"
      >
        <td class="text-right font-weight-bold">{{ item.name }}</td>
        <td class="text-right font-weight-bold">+{{ item.Day }}%</td>
        <td class="text-right font-weight-bold">+{{ item.Week }}%</td>
        <td class="text-right font-weight-bold">+{{ item.Month }}%</td>
      </tr>
    </tbody>
  </v-table>
</v-card>
</template>

<script lang="ts">
export default {
  name: 'OverviewStatsCard',
  props: {
    accounts: {
      type: Array,
      required: true,
    }
  },
  data () {
    return {
      TimeFrames: [
        {
          name: 'MATIC',
          Day: 2,
          Week: 3,
          Month: 4,
        },
    ],
  }
}
}
</script>