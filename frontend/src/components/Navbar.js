import { 
  AppBar, 
  Toolbar, 
  Typography 
} from '@mui/material';

function Navbar () {
  return (
    <AppBar position="static">
      <Toolbar variant="dense">
        <Typography>
          Novels!
        </Typography>
      </Toolbar>
    </AppBar>
  )

}


export default Navbar; 