<template>
  <v-row align="center">
    <v-sheet color="green lighten-2" class="ma-10">
      <v-card>
        <v-row align="center" justify="center">
          <v-card class="text-center">
            <v-card-title>
              <v-spacer />
              Solar Generation
              <v-spacer />
            </v-card-title>
          <v-card-text>
            We are proud of being the newest addition to the Vita Vehiculum
            family and support their manufacturing capabilities with over 15
            acres of solar farms throughout the country. Currently our largest
            farm, Sonneberg Fields, has capabilities of generation approximately
            14000 kW/h of electricity. Our mission has always been clean energy
            and our solar generation efforts are our star in that. Please out
            via the Contact Us page for more information regarding commercial
            utilization.
          </v-card-text>
          </v-card>
        </v-row>
      </v-card>
    </v-sheet>
  </v-row>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component
export default class SolarGeneration extends Vue {}
</script>
