<script setup>
import { onMounted, ref, computed } from "vue";
import { useMouse } from "@vueuse/core";

const { x, y } = useMouse();
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
    <div class="background-clear"></div>
    <div class="background"></div>
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
  background: url('img/background/bg-Main.jpg') center/cover no-repeat;
  filter: blur(10px);
  z-index: -3;
  background-color: rgba(0, 0, 0, 0.4);
}

.background-clear {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: url('img/background/bg-Main.jpg') center/cover no-repeat;
  filter: blur(4px);
  z-index: -2;
  mask-image: radial-gradient(circle at center, white 20%, black 75%);
  mask-repeat: no-repeat;
  mask-mode: luminance;
  mask-size: 100%;
  mask-position: v-bind(maskPosition);
  background-color: rgba(0, 0, 0, 0.2);
  -webkit-mask-clip: stroke-box;
  mask-clip: stroke-box;
  -webkit-mask-origin: border-box;
  mask-origin: border-box;
}
</style>