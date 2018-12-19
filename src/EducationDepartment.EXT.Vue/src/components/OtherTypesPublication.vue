<template>
  <div class="singIn">
     
       
      <form class="form-signin">

        <h1 class="h3 mb-3 font-weight-normal">{{articleType.name}} </h1>

		<div class="card mb-3" v-for="(field, index) in articleType.fields ">
  <div class="card-body">
     

   
	<div class="filed-form">
 
    <h1 class="h3 mb-3 font-weight-normal">{{field.name}} </h1>

 <div v-if="field.type == 'textInput'">
  <input type="text" class="form-control">
</div>
<div v-else-if="field.type =='date'">
  <input class="form-control" type="date" value="2018-12-19">
</div>
<div v-else-if="field.type =='imageUpload'">
   
                  <div class="input-group">
                    <span class="input-group-btn">
                      <span class="btn btn-default btn-file">
                        Wybierz… <input type="file" id="imgInp">
                </span>
                    </span>
                    <input type="text" class="form-control" readonly="">
        </div>
                   
</div>
<div v-else-if="field.type =='inputFile'">
  <input type="file" class="form-control-file" id="exampleInputFile" aria-describedby="fileHelp">
</div>
<div v-else>
<textarea class="form-control"  rows="5"></textarea>
</div>

    

      
	</div>
  </div>
</div>
		<button   class="btn btn-lg btn-primary btn-block">Dodaj {{articleType.name}}</button>
             
          </form>
      
     
  </div>
</template>

<script>
export default {
  name: "PublicationGenerate",
  data() {
    return {
      articleType: {
        name: "Przykład",
        fields: [
          { name: "Autor", type: "textInput" },
          { name: "Załącznik", type: "inputFile" },
          { name: "Okładka", type: "imageUpload" },
          { name: "Opis", type: "description" }
        ]
      }
    };
  },
  methods: {
    createField() {}
  }
};
</script>

 
</style>
