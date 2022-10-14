<template>
   <div class="search-form">
      <div class="grid-item">
         <i-new-input 
            ref="search"
            v-model="search"
            :name="'search'"
            :placeholder="'Поиск'"
            :type="'text'"
            :required="false"
            @enter="$emit('search', search)"
            isStandart
            greyBorder
            search
         >
         </i-new-input>
      </div>
      <div class="i-button-wrap">
         <i-button @onClick="$emit('search', search)">Поиск</i-button>
      </div>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

@Component
export default class SearchFormComponent extends Vue {

   search: string = ''

   @Watch('search') changeSearch() {
      if (this.search == '')
         this.$emit('searchEmpty', this.search)
   }


}
</script>

<style scoped>

.search-form {
   margin-bottom: 10px;
   display: flex;
   align-items: center;
}

.grid-item {
   margin-right: 15px;
   flex: 1 1 auto;
   width: 100%;
}

@media all and (max-width: 340px) {
   .search-form { flex-direction: column; align-items: flex-start; }
   .grid-item { margin-right: 0; margin-bottom: 15px; }
}
</style>