<template>
   <div class="slider-wrap" v-if="partnersArr" tabindex="0">
      <div class="slider-partners i-slider">
         <div v-for="item in partnersArr" :key="item.Id" class="slide">
            <router-link :to="item.Link" class="partner">
               <img :src="item.Image" alt="">
            </router-link>
         </div>
      </div>

      <div class="i-slider-arrows partners-arrows"></div>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop } from "vue-property-decorator"

// import $ from "jquery";
import PartnersModel from "./models/PartnersModel"

@Component
export default class PartnersComponent extends Vue {

   partnersArr: PartnersModel[] = []  // массив с отзывами

   created() {
      this.partnersArr = [
         new PartnersModel(1, '/assets/img/partners/metlife.webp', 'metlife'),
         new PartnersModel(2, '/assets/img/partners/uniqa.webp', 'uniqa'),
         // new PartnersModel(3, '/assets/img/partners/taslife.webp', 'taslife'),
         // new PartnersModel(4, '/assets/img/partners/grawe.webp', 'grawe')
      ]
   }

   mounted() {
      this.initSlickSlider()
      window.addEventListener('resize', this.onGroupArrows)
   }

   /**
    * Инициализация slick-slider
    */
   initSlickSlider() {
      $('.slider-partners').slick({
         slidesToShow: 2,
         slidesToScroll: 2,
         infinite: true,
         dots: false,
         arrows: true,
         prevArrow: '<button class="i-slider-arrow partners-arrow prev"><svg><use xlink:href="/assets/img/svg-sprite.svg#arrow-right-long"></use></svg></button>',
         nextArrow: '<button class="i-slider-arrow partners-arrow next"><svg><use xlink:href="/assets/img/svg-sprite.svg#arrow-right-long"></use></svg></button>',
         adaptiveHeight: true,
         responsive: [
            {
               breakpoint: 960,
               settings: {
                  slidesToShow: 2,
                  adaptiveHeight: true,
                  arrows: true,
                  prevArrow: '<button class="i-slider-arrow partners-arrow prev"><svg><use xlink:href="/assets/img/svg-sprite.svg#arrow-right-long"></use></svg></button>',
                  nextArrow: '<button class="i-slider-arrow partners-arrow next"><svg><use xlink:href="/assets/img/svg-sprite.svg#arrow-right-long"></use></svg></button>',
               }
            },
            {
               breakpoint: 600,
               settings: {
                  centerMode: false,
                  centerPadding: '50px',
                  slidesToScroll: 1,
                  slidesToShow: 1,
                  arrows: true,
                  adaptiveHeight: true,
                  prevArrow: '<button class="i-slider-arrow partners-arrow prev"><svg><use xlink:href="/assets/img/svg-sprite.svg#arrow-right-long"></use></svg></button>',
                  nextArrow: '<button class="i-slider-arrow partners-arrow next"><svg><use xlink:href="/assets/img/svg-sprite.svg#arrow-right-long"></use></svg></button>',
               }
            }
         ]
      })

      this.onGroupArrows()
   }

   onGroupArrows() {
      $('.partners-arrows').append($('.partners-arrow'))
      $('.partners-arrow').css({ display: 'flex' })
   }
   

}
</script>

<style scoped>


/* slider */
.slide {
   padding: 15px 5px;
}

.i-slider-arrows {
   display: flex;
   align-items: center;
   justify-content: center;
   width: 100%;
}



.partner {
   padding: 5px;
   display: flex;
   flex-direction: column;
   align-items: center;
   justify-content: center;
   width: 100%;
   min-height: 156px;
   position: relative;
   /* box-shadow: 0 0 42px rgba(0, 0, 0, 0.1); */
   background: #fff;
   border-radius: 15px;
   overflow: hidden;
   cursor: pointer;
   transition: all 0.3s ease-out;
}

.partner img {
   max-width: 430px;
   width: 100%;
   max-height: 146px;
   height: auto;
}

.partner:hover {
   transform: translateY(-7px);
}


</style>

<style>
.i-slider-arrow {
   margin: 0 10px;
   background: transparent;
   display: flex;
   align-items: center;
   opacity: 0;
   visibility: hidden;
   transition: all 0.3s ease-out;
}

.i-slider-arrow svg {
   width: 40px;
   height: 40px;
   fill: #12be83;
   transition: all 0.3s ease-out;
}

.i-slider-arrow.prev svg {
   transform: rotate(180deg);
}

.i-slider-arrow:hover svg,
.i-slider-arrow:focus svg {
   fill: #0da671;
}


.i-slider-arrow.prev {
   transform: translateX(-10px);
}

.i-slider-arrow.next {
   transform: translateX(10px);
}

.slider-wrap:hover .i-slider-arrow,
.slider-wrap:focus .i-slider-arrow {
   opacity: 1;
   visibility: visible;
   transform: translateX(0);
}


</style>