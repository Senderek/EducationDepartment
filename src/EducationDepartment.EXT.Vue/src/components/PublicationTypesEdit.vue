<template>
<div class="container" style="margin-top:50px">
  <h1>Edytuj {{publicationTypes[ide-1].type}}</h1>
  <from >
    <input type="text" class="form-control mb-2" placeholder="Nazwa typu publikacji"  v-model="publicationTypes[ide-1].type" >
   <div >
  <div class="card mb-3" v-for="(pubT, index) in publicationTypes[ide-1].fields ">
  <div class="card-body">
    <span class="float-right" style="cursor:pointer" @click="deleteFieldForm(index)">
      X
    </span>

    <h4 class="card-title">Edytuj pole </h4>
	<div class="filed-form">
    <input type="text" class="form-control mb-2" placeholder="Nazwa pola" v-model="pubT.name">
         
           <select  v-model="selected" class="form-control" id="TypesFieldsList">
        <option v-for="fieldType in fieldTypes" v-bind:value="fields.type">
          {{fieldType.type}}
        </option>
      </select>

     

      
	</div>
  </div>
</div>
 </div>
	  <from >
    
  <div class="card mb-3" v-for="(field, index) in fields ">
  <div class="card-body">
    <span class="float-right" style="cursor:pointer" @click="deleteFieldForm(index)">
      X
    </span>

    <h4 class="card-title">Dodaj pole  </h4>
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
</from>
  <button   class="btn btn-lg btn-primary btn-block">Edytuj typ publikacji</button>
</from>
</div>


</template>

<script>
  export default {
  name: 'NewTypePublication',
  data(){
  return{
  ide: this.$route.params.id,
  fields:[{name:'',type:''}],
  fieldTypes:[{type: 'Pole tekstowe',id:'1'},{type: 'Data',id:'2'},{type: 'Załącznik',id:'3'},{type: 'Duże pole tekstowe',id:'4'}],
  publicationTypes: [
    {type: 'Artykuł',id:'1',fields: [
            {name:'Autor',fieldTypesId:'0'
            },
            {name:'Tytuł',fieldTypesId:'0'
            },
            {name:'Opis',fieldTypesId:'3'
            },
            {name:'Nazwa czasopisma/magazynu',fieldTypesId:'0'
            },
            {name:'data',fieldTypesId:'1'
            },
            {name:'Strony',fieldTypesId:'0'
            },
            {name:'Okładka',fieldTypesId:'4'
            },
            {name:'Załączniki',fieldTypesId:'2'
            }
        ]
    },
    {type: 'Monografia',id:'2',fields: [
            {name:'Autor',fieldTypesId:'0'
            },
            {name:'Tytuł',fieldTypesId:'0'
            },
            {name:'Opis',fieldTypesId:'3'
            },
            {name:'Nazwa czasopisma/magazynu',fieldTypesId:'0'
            },
            {name:'data',fieldTypesId:'1'
            },
            {name:'Miasto',fieldTypesId:'0'
            },
            {name:'Wydawca',fieldTypesId:'0'
            },
            {name:'Okładka',fieldTypesId:'4'
            },
            {name:'Załączniki',fieldTypesId:'2'
            }
        ]
        },
        {type: 'Książka',id:'3',fields: [
            {name:'Autor',fieldTypesId:'0'
            },
            {name:'Tytuł',fieldTypesId:'0'
            },
            {name:'Opis',fieldTypesId:'3'
            },
            {name:'data',fieldTypesId:'1'
            },
            {name:'Miasto',fieldTypesId:'0'
            },
            {name:'Wydawca',fieldTypesId:'0'
            },
            {name:'Okładka',fieldTypesId:'4'
            },
            {name:'Załączniki',fieldTypesId:'2'
            }
        ]
        },
        {type: 'Raport',id:'4',fields: [
            {name:'Autor',fieldTypesId:'0'
            },
            {name:'Tytuł',fieldTypesId:'0'
            },
            {name:'Opis',fieldTypesId:'3'
            },
            {name:'data',fieldTypesId:'1'
            },
            {name:'Miasto',fieldTypesId:'0'
            },
            {name:'Wydawca',fieldTypesId:'0'
            },
            {name:'Okładka',fieldTypesId:'4'
            },
            {name:'Załączniki',fieldTypesId:'2'
            }
        ]
        },
        {type: 'Patent',id:'5',fields: [
            {name:'Wynalazca',fieldTypesId:'0'
            },
            {name:'Tytuł',fieldTypesId:'0'
            },
            {name:'Opis',fieldTypesId:'3'
            },
            {name:'data',fieldTypesId:'1'
            },
            {name:'Kraj/region',fieldTypesId:'0'
            },
            {name:'Numer patentu',fieldTypesId:'0'
            },
            {name:'Okładka',fieldTypesId:'4'
            },
            {name:'Załączniki',fieldTypesId:'2'
            }
        ]
        },
        {type: 'Materiał konferncyjny',id:'6',fields: [
            {name:'Autor',fieldTypesId:'0'
            },
            {name:'Tytuł',fieldTypesId:'0'
            },
            {name:'Opis',fieldTypesId:'3'
            },
            {name:'data',fieldTypesId:'1'
            },
            {name:'Konferencja',fieldTypesId:'0'
            },
            {name:'Miasto',fieldTypesId:'0'
            },
            {name:'Okładka',fieldTypesId:'4'
            },
            {name:'Załączniki',fieldTypesId:'2'
            }
        ]
        },
        {type: 'Przykład',id:'7',fields: [
            {name:'Autor',fieldTypesId:'0'
            },
            {name:'Przykład',fieldTypesId:'3'
            },
            {name:'Data',fieldTypesId:'1'
            }
        ]
        }
    ]
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
  },
    deleteFieldFormv2(index)
  { let x=publicationTypes[ide-1].fields;
  this.x.splice(index,1)
  }
  }

  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">
</style>
