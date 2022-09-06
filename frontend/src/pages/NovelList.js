import React from 'react';

import { 
  TextField,
  Button,
  FormControl
} from '@mui/material';

function NovelList () {
  const [novels, setNovels] = React.useState([]);

  function updateNewNovel() {
    
  }

  async function addNovel() {

  }

  return (
    <>

      { /* Display all novels */
        novels.map((q, i) => {
          return (
          <div>
            A novel will be displayed here
          </div>);
        })
      }


      {/* Form to submit new novels */}
      <FormControl>
        <TextField id="novel-title" label="Novel Title" variant="outlined" />
        <TextField id="novel-descrip" label="Novel Description" variant="outlined" />
        <Button
          color='primary'
          variant='outlined'
          onClick={addNovel}
        >
          Add Novel
        </Button>
      </FormControl>
    </>
  );
}

export default NovelList;