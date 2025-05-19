<script setup>
import Background from './Background.vue';
</script>
<template>
    <div id="Box">
        <Background />
        <div id="Content">
            <h1 id="Word">Hello World</h1>
        </div>
    </div>
</template>

<style scoped>
#Box {
  width: 600px;
  height: 800px;
  margin: 0 0;

};
#Content  {
    top: 820px;
}

</style>