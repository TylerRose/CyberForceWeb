<template>
  <v-card>
    <v-row justify="center">
      <v-sheet color="green lighten-3" height="400">
        <v-img width="1000" aspect-ratio="1" class="fill-height" :src="require('@/assets/solarpanels.png')"/>
      </v-sheet>
    </v-row>
    <v-row justify="center" class="pa-3">
      <v-card height="400" width="800">
        <v-row class="pa-2">
          <v-col>
            <v-row justify="center">
              <v-card-title>
              Contact Information
              </v-card-title>
              <v-card-text>
                Welcome to Sole-Zon-Solis Energy, we are happy to answer any questions you might have about our
                services. Please fill out the contact us form and we will get back to you shortly!
              </v-card-text>
              <v-card-text>
                Phone Number
              </v-card-text>
              <v-card-text>
                Email Addresss
              </v-card-text>
            </v-row>
          </v-col>
          <v-col>
            <v-row justify="center">
              <v-card-title>
                Contact Information
              </v-card-title>
            </v-row>
          </v-col>
        </v-row>
      </v-card>
    </v-row>
  </v-card>

</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component
export default class Contact extends Vue {

}
</script>
