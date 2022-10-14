<template>
	<div class="cr-c">
		<!-- кроп -->
		<div class="cr-f" ref='cr'>
            <crop-image-background
                :imageSrc="imageSrc"
                :maxHeight="maxHeight"
                :maxWidth="maxWidth"
                :height="height"
                :width="width"
                :frameHeight="prevParams.height"
                :frameWidth="prevParams.width"
                :frameTop="prevParams.top"
                :frameLeft="prevParams.left"
                @loaded="loaded">
            </crop-image-background>
      
            <crop-image-frame 
                ref="frame"
                :isLiveUpdate="isLiveUpdate"
                :type="type"
                :imageSrc="imageSrc"
                :aspectRatio="aspectRatio"                
                :frameTop="prevParams.top"
                :frameLeft="prevParams.left"
                @update="updateCropParams">
                
            </crop-image-frame>
        </div>
    </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator"
@Component({
    name: 'crop-image'
})
export default class CropImageComponent extends Vue {
    @Prop() type: string;    
    @Prop() aspectRatio: number;
    @Prop() imageSrc: string;
    @Prop() maxHeight: number;
    @Prop() maxWidth: number;
    @Prop() height: number;
    @Prop() width: number;
    @Prop({default: false}) isLiveUpdate: boolean;
    @Prop({default: () => { return { 
                        left: 0,
                        top: 0,
                        height: 0,
                        width: 0
                    }}}) prevParams: PrevParams;
    realWidth = 0;
    realHeight = 0;    
    loaded(data: any){
        (this.$refs.frame as any).show(data);
        this.realHeight = data.height;
        this.realWidth = data.width;
    }
    getCropParams(){
        this.$emit('height', this.realHeight);
        return (this.$refs.frame as any).getParams(); 
    }
    forceUpdate() {
        (this.$refs.frame as any).forceUpdate();
    }
    updateCropParams(data: any){ 
        this.$emit('update', data);
    }
    
};
export interface PrevParams {
    left: number;
    top: number;
    height: number;
    width: number;
}
</script>

<style lang="less" scoped>
.cr-c {
    position: relative;
    margin: auto;
    display: flex;
    flex-direction: column;
    align-items: center;
}
.cr-f {
    position: relative;
}
.cr-preview {
    text-align: center;
    padding: 20px;
    .cr-max-preview,
    .cr-min-preview {
        border-radius: 50%;
        position: relative;
        overflow: hidden;
    }
    .cr-max,
    .cr-min {
        position: absolute;
        z-index: 2;
    }
    .cr-min-preview {
        height: 50px;
	    width: 175px;
        margin: auto;
        margin-top: 10px;
    }
}
</style>