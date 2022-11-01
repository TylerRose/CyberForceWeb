<template>
  <v-card>
    <v-row justify="center">
      <v-sheet color="green lighten-3" height="400">
        <v-img width="1000" aspect-ratio="1" class="fill-height" :src="require('@/assets/solarpanels.png')"/>
      </v-sheet>
    </v-row>
    <v-row justify="center" class="pa-3">
      <v-card height="400" width="800">
        <v-card-title class="justify-center"> Sonnenberg Fields</v-card-title>
        <v-row class="pa-2">
          <v-col>
            <v-list>
              <v-list-item v-for="array in solarArrays">

              </v-list-item>
            </v-list>
          </v-col>
          <v-col>
          <v-list>
            <v-list-item v-for="power in powerGeneration">
            </v-list-item>
          </v-list>
          </v-col>
        </v-row>
      </v-card>
    </v-row>
  </v-card>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component({})
export default class Home extends Vue {

  solarArrays: any = [];
  powerGeneration: any = [];



  created(){

  }
}
</script>
