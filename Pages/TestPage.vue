<template>
  <h1>TestPage Vue</h1>
  <h1>{{ message }}</h1>
  <h1>{{ user.firstName }}</h1>
</template>

<script setup>
import { onMounted, ref } from "vue";
const message = ref("HELLO!");
const user = ref({});
onMounted(async () => {
  message.value = await (await fetch("TestPage/test")).json();
  user.value = await (await fetch("TestPage/amanda")).json();
});
</script>
