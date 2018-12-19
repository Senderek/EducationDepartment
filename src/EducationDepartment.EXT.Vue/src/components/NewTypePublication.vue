<template>
<div class="container" style="margin-top:50px">
  <h1>Dodaj nowy typ publikacji</h1>
  <from >
    <input type="text" class="form-control mb-2" placeholder="Nazwa typu publikacji"  >
  <div class="card mb-3" v-for="(field, index) in fields ">
  <div class="card-body">
    <span class="float-right" style="cursor:pointer" @click="deleteFieldForm(index)">
      X
    </span>

    <h4 class="card-title">Dodaj pole nr {{index + 1}})</h4>
	<div class="filed-form">
    <input type="text" class="form-control mb-2" placeholder="Nazwa pola" v-model="field.name">

      <select  v-model="selected" class="form-control" id="TypesFieldsList">
        <option v-for="fieldType in fieldTypes" v-bind:value="fields.type">
          {{fieldType.type}}
        </option>
      </select>

      
	</div>
  </div>
</div>
	<button class="btn btn-success mt-5 mb-5" @click="addNewFieldForm">
    Nowe pole
	</button>
  <button   class="btn btn-lg btn-primary btn-block">Dodaj typ publikacji</button>
</from>
</div>


</template>

<script>
  export default {
  name: 'NewTypePublication',
  data(){
  return{
  fields:[{name:'',type:''}],
  fieldTypes:[{type: 'Pole tekstowe'},{type: 'Data'},{type: 'Załącznik'},{type: 'Duże pole tekstowe'}]
  }

  },
  methods: {
  addNewFieldForm() {
  this.fields.push({
  name: '',
  type: ''
  })},
  deleteFieldForm(index)
  {
  this.fields.splice(index,1)
  }
  }

  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">
</style>
