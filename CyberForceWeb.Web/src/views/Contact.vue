<template>
  <v-card>
    <v-row justify="center">
      <v-sheet color="green lighten-3" height="400" >
        <v-img
          width="1000"
          aspect-ratio="1"
          class="fill-height"
          :src="require('@/assets/solarpanels.png')"
        />
      </v-sheet>
    </v-row>
    <v-row justify="center" class="pa-3 text-center">
      <v-card height="450" width="800">
        <v-row class="pa-2">
          <v-col>
            <v-row justify="center">
              <v-card-title> Contact Information
              </v-card-title>
              <v-card-text>
                Welcome to Sole-Zon-Solis Energy, we are happy to answer any
                questions you might have about our services. Please fill out the
                contact us form and we will get back to you shortly!
              </v-card-text>
              <v-card-text> 1 (800) 800 8553</v-card-text>
              <v-card-text> contactus@solis.com</v-card-text>
            </v-row>
          </v-col>
          <v-col>
            <v-row justify="center">
              <v-card-title> Contact Information</v-card-title>
              <v-alert v-model="showSuccess" color="green" dismissible>
                Your message has been sent!
              </v-alert>
              <v-card-text>
                <c-input :model="contactForm" for="name"></c-input>
                <c-input :model="contactForm" for="email"></c-input>
                <c-input :model="contactForm" for="phoneNumber"></c-input>
                <v-file-input v-model="uploadedFile" label="File Upload" />
              </v-card-text>
              <v-card-actions>
                <v-btn @click="submit">Submit</v-btn>
              </v-card-actions>
            </v-row>
          </v-col>
        </v-row>
      </v-card>
    </v-row>
  </v-card>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { ContactUsFormViewModel, UploadServiceViewModel, FileUploadViewModel } from "@/viewmodels.g";

@Component
export default class Contact extends Vue {
  contactForm = new ContactUsFormViewModel();
  uploadService = new UploadServiceViewModel();
  uploadedFile: File | null = null;
  showSuccess = false;

  async submit() {
    if (this.uploadedFile) {
      await this.uploadService.uploadFile(
        this.uploadedFile,
        this.contactForm.contactUsFormId
      );
      this.contactForm.upload = new FileUploadViewModel(
        this.uploadService.uploadFile.result
      );
    }

    await this.contactForm.$save();
    this.showSuccess = true;
    this.contactForm = new ContactUsFormViewModel();
    this.uploadedFile = null;
  }
}
</script>
