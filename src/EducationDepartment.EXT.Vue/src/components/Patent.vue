<template>
  <div class="patent">
    <h3>Dodaj patent</h3>

    <form style ="margin-top:20px">
      <div class="form-group">
        <label for="autorImput">Wynalazca</label>
        <input type="text" class="form-control" id="autorImput" placeholder="wynalazca">
          </br>

          <label for="titleImput">Tytuł</label>
          <input type="text" class="form-control" id="titleImput" placeholder="tytuł">
            </br>

            <label for="descriptionBook">Opis</label>
            </br>
            <textarea class="form-control" id="descriptionBook" rows="5"></textarea>
            </br>

            <label for="example-date-input"  >Data</label>
            </br>

            <input class="form-control" type="date" value="2018-11-19" id="example-date-input">
              </br>

              <label for="areaInput">Kraj/region</label>
              <input type="text" class="form-control" id="areaInput" placeholder="kraj/region">
                </br>

                <label for="numberOfPatentInput">Numer patentu</label>
                <input type="text" class="form-control" id="numberOfPatentInput" placeholder="numer patentu">
                  </br>




                <label for="cityImput">Miasto</label>
                <input type="text" class="form-control" id="cityImput" placeholder="miasto">
                  </br>

               






                    <label>Okładka</label>
                    <div class="input-group">
                      <span class="input-group-btn">
                        <span class="btn btn-default btn-file">
                          Wybierz… <input type="file" id="imgInp">
                </span>
                      </span>
                      <input type="text" class="form-control" readonly="">
        </div>
                    <img id='img-upload'/>




                    <label for="exampleInputFile">Załączniki</label>
                    <input type="file" class="form-control-file" id="exampleInputFile" aria-describedby="fileHelp">
                      <small id="fileHelp" class="form-text text-muted">This is some placeholder block-level help text for the above input. It's a bit lighter and easily wraps to a new line.</small>


                      <button   class="btn btn-lg btn-primary btn-block">Dodaj patent</button>


                    </div>

    </form>

  </div>
</template>

<script>
  export default {
  name: 'Patent',
  data(){
  return{}
  }
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">
</style>
