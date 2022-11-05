<template>
  <v-card>
    <v-row>
      <v-card width="500">
        <v-card-title>
          <v-spacer/>
          Emails
          <v-spacer/>
        </v-card-title>
        <v-card-text>
          <v-list v-if="emails.$items.length>0" :key="'emails'+emails.$items.length">
            <v-list-item v-for="item in emails.$items">
                {{item.name}}
                {{item.email}}
                {{item.phoneNumber}}
              </v-list-item>
            </v-list>
        </v-card-text>
      </v-card>
    </v-row>
    <v-row>
      <v-card width="500">
        <v-card-title>
          <v-spacer/>
          Files
          <v-spacer/>
        </v-card-title>
        <v-card-text>
            <v-list v-if="files.$items.length>0" :key="'files'+files.$items.length">
              <v-list-item v-for="item in files.$items.filter(i=>i.fileName!==null)">
                {{item.fileName}}
              </v-list-item>
            </v-list>
        </v-card-text>
      </v-card>
    </v-row>
  </v-card>
</template>

<script lang="ts">
import {Component, Vue} from "vue-property-decorator";
import {ContactUsFormListViewModel, FileUploadListViewModel,} from "@/viewmodels.g";

@Component
export default class Admin extends Vue {
  files: FileUploadListViewModel = new FileUploadListViewModel();
  emails: ContactUsFormListViewModel = new ContactUsFormListViewModel();

  async created() {
    await this.files.$load();
    await this.emails.$load();
    console.log(this.files.$items);
    console.log(this.emails.$items);
  }
}
</script>

<style scoped></style>
