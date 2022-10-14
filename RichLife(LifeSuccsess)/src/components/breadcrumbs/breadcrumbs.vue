<template>
   <div class="breadcrumbs">
      <slot />
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator"

@Component
export default class BreadCrumbsComponent extends Vue {

}
</script>

<style scoped>

.breadcrumbs {
   margin: 20px auto;
   padding: 0 14px;
   display: flex;
   align-items: center;
   flex-wrap: wrap;
   max-width: 1320px;
   position: relative;
   z-index: 1;
}


.breadcrumbs.light a,
.breadcrumbs.light span {
   color: #fff;
}

.breadcrumbs a, .breadcrumbs span {
   display: flex;
   align-items: center;
   flex-wrap: nowrap;
   font-size: 13px;
   font-weight: 500;
   line-height: 140%;
   color: #121B23;
   transition: all 0.1s ease-out;
}

.breadcrumbs span,
.breadcrumbs.light span {
   margin: 0;
   color: #12be83;
}

.breadcrumbs a:hover {
   color: #12be83;
}

.breadcrumbs a:hover span {
   color: #121B23;
}

.breadcrumbs.light a:hover span {
   color: #fff;
}

</style>

<style>

.breadcrumbs .slash {
   padding: 0 7px;
   display: inline-block;
   color: #121B23;
}

.breadcrumbs.light .slash {
   color: #fff;
}

.breadcrumbs a svg {
   margin: 0 7px;
   width: 13px;
   height: 13px;
   fill: #121B23;
}

.breadcrumbs.light a svg {
   fill: #fff;
}
</style>