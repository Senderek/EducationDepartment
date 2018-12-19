<template>
  <div class="publicationTypes container">
    <Alert v-if="alert" v-bind:message="alert" />
    <h1 class="page-header">Typy publikacji</h1>

    <br />

    <router-link to="/publicationType/new">
      <button type="button" class="btn btn-success ml-2">Dodaj typ publikacji</button>
    </router-link>
    
    <table class="table table-striped">
      <thead>
        <tr>
          <th>Nazwa typu</th>
          <th>Edytuj</th>
          <th>Usuń</th>

          <th></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(publicationType,index) in publicationTypes">
          <td>{{publicationType.type}}</td>

          <td>
            <router-link class="btn btn-warning" v-bind:to="'/publicationTypes/edit/'+publicationType.id">Edytuj</router-link>
          </td>
          <td>
            <button type="button" class="btn btn-danger"  @click="deleteFieldForm(index)">
              Usuń
            </button>
             
          </td>

          
          
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
  import Alert from './Alert';
  export default {
  name: 'PublicationTypes',
  data () {
  return {
  publicationTypes: [{type: 'Artykuł',id:'1'},{type: 'Monografia',id:'2'},{type: 'Książka',id:'3'},{type: 'Raport',id:'4'},{type: 'Patent',id:'5'},{type: 'Materiał konferncyjny',id:'6'},{type: 'Przykład',id:'7'}],
  alert:'',
  }
  },
  methods: {
  fetchPublicationTypes(){
  this.$http.get('https://localhost:44335/api/GetAllArticleTypes')
  .then(function(response){
  this.publicationTypes = response.body;
  });
  },
  deleteFieldForm(index)
  {
  this.publicationTypes.splice(index,1)
  }
  }
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">
</style>
