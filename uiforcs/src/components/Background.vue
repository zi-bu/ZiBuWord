<script setup>
import { onMounted, ref, computed } from "vue";
import { useMouse } from "@vueuse/core";
const maxOffset = 1; // 最大平移像素，可根据需要调整
const centerX = 300; // 容器宽度一半
const centerY = 400; // 容器高度一半
const offsetX = computed(() => -((relativeX.value - centerX) / centerX) * maxOffset);
const offsetY = computed(() => -((relativeY.value - centerY) / centerY) * maxOffset);



const containerRef = ref(null)

const maskPosition = computed(() => `${relativeX.value - 300}px ${relativeY.value - 400}px`);
const { relativeX, relativeY } = useContainerMouse()

function useContainerMouse() {
  const { x, y } = useMouse()

  const relativeX = computed(() => {
    const rect = containerRef.value?.getBoundingClientRect()
    return rect ? x.value - rect.left : 0
  })

  const relativeY = computed(() => {
    const rect = containerRef.value?.getBoundingClientRect()
    return rect ? y.value - rect.top : 0
  })

  return { relativeX, relativeY }
}

</script>

<template>
  <div id="window" ref="containerRef" class="card">
    <div class="background-clear" :style="{
      transform: `translate(${offsetX}px, ${offsetY}px)`
    }"></div>
    <div class="background" :style="{
      transform: `translate(${offsetX}px, ${offsetY}px)`
    }"></div>
  </div>
</template>

<style scoped>
#window {
  height: 800px;
  width: 600px;
  color: black;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  z-index: -1;
  position: absolute;
}

.background {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: url('img/background/2.jpg') center/cover no-repeat;
  filter: blur(1px);
  z-index: -3;
  background-color: rgba(0, 0, 0, 0.4);
  background-size: 105% 105%;
}


.background-clear {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: url('img/background/2.jpg') center/cover no-repeat;
  filter: blur(0px);
  z-index: -2;
  mask-image: radial-gradient(circle at center, white 30%, black 75%);
  mask-repeat: no-repeat;
  mask-mode: luminance;
  mask-size: 100%;
  mask-position: v-bind(maskPosition);
  background-color: rgba(0, 0, 0, 0.2);
  -webkit-mask-clip: stroke-box;
  mask-clip: stroke-box;
  -webkit-mask-origin: border-box;
  mask-origin: border-box;
  background-size: 105% 105%;
}
</style>