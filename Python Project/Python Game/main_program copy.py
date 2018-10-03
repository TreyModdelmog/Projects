import pygame
import random

BLACK = (0, 0, 0)
WHITE = (255, 255, 255)
RED = (255, 0, 0)
BLUE = (0, 0, 255)
screen_width = 700
screen_height = 400

# --- Classes and functions

class Block(pygame.sprite.Sprite):
    
    def __init__(self, color):
        super().__init__()
        
        self.change_y = 1
        
        self.image = pygame.image.load("meteorGrey_big2.png").convert()
        self.image.set_colorkey(WHITE)

        self.rect = self.image.get_rect()
    
    def update(self):
        self.rect.y += self.change_y
        
        if self.rect.y >= 400:
            self.rect.y = -25

 
class Player(pygame.sprite.Sprite):
    
    def __init__(self):
        super().__init__()

        self.image = pygame.image.load("playerShip2_red.png").convert()
        self.image.set_colorkey(WHITE)

        self.rect = self.image.get_rect()

    def update(self):
        pos = pygame.mouse.get_pos()
        pygame.mouse.set_visible(0)

        self.rect.x = pos[0]


class Bullet(pygame.sprite.Sprite):
    
    def __init__(self):
        super().__init__()

        self.image = pygame.image.load("laserBlue13.png").convert()
        self.image.set_colorkey(WHITE)

        self.rect = self.image.get_rect()

    def update(self):
        self.rect.y -= 3

class Game(object):
    
    def __init__(self):
        self.level = 1
        self.score = 0
        self.lives = 5
        
        self.font = pygame.font.SysFont('Calibri', 20, True, False)
        self.font2 = pygame.font.SysFont("serif", 25) 
        
        self.game_over = False
        
        self.background_image = pygame.image.load("Screen-shot-2012-04-13-at-2.24.50-PM.jpg").convert()
        self.background_position = [0, 0]
        #self.click_sound = pygame.mixer.Sound("249618__vincentm400__invalid.ogg")
        
        # --- Sprite lists
        
        self.all_sprites_list = pygame.sprite.Group()
        self.block_list = pygame.sprite.Group()
        self.bullet_list = pygame.sprite.Group()
        
        # --- Create the sprites
        
        self.create_sprites(self.level)
        
        self.player = Player()
        self.player.rect.y = 370
        self.all_sprites_list.add(self.player)        

    def create_sprites(self, speed):
        for i in range(50):
            block = Block(BLACK)
            block.rect.x = random.randrange(screen_width - 15)
            block.rect.y = random.randrange(250)
            block.change_y = speed
        
            self.block_list.add(block)
            self.all_sprites_list.add(block)
        

    def draw_text(self, screen):
        text = self.font.render("Score " + str(self.score), True, WHITE)
        screen.blit(text, [10, 10])  
        
        text = self.font.render("Level " + str(self.level), True, WHITE)
        screen.blit(text, [10, 370])
        
        text = self.font.render("Lives " + str(self.lives), True, WHITE)
        screen.blit(text, [630, 370])     
    
    def event_process(self):
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                return True
    
            elif event.type == pygame.MOUSEBUTTONDOWN:
                bullet = Bullet()
                bullet.rect.x = self.player.rect.x + 12
                bullet.rect.y = self.player.rect.y
                self.all_sprites_list.add(bullet)
                self.bullet_list.add(bullet)
                #self.click_sound.play()
            
            elif event.type == pygame.KEYDOWN:
                if event.key == pygame.K_SPACE:
                    if self.game_over:
                        self.__init__()
        return False
    
    def run_logic(self):
        
        if not self.game_over:
            
            self.all_sprites_list.update()
            
            for bullet in self.bullet_list:
        
                block_hit_list = pygame.sprite.spritecollide(bullet, self.block_list, True)
        
                for block in block_hit_list:
                    self.bullet_list.remove(bullet)
                    self.all_sprites_list.remove(bullet)
                    self.score += 1
                    print(self.score)          
                
                if bullet.rect.y < -10:
                    self.bullet_list.remove(bullet)
                    self.all_sprites_list.remove(bullet)    
            
                if len(self.block_list) == 0:
                    self.level += 1
                    self.create_sprites(self.level / 2)
             
            for block in self.block_list:
                block_hit_list = pygame.sprite.spritecollide(self.player, self.block_list, True)
                for block in block_hit_list:
                    self.lives -= 1
            if self.lives <= 0:
                self.game_over = True
                                    
    def display(self, screen):
        screen.fill(WHITE)
        screen.blit(self.background_image, self.background_position)
        
        if not self.game_over:
            self.all_sprites_list.draw(screen)
        
        if self.game_over:
            text = self.font2.render("Game Over, click to restart", True, WHITE)
            center_x = (screen_width // 2) - (text.get_width() // 2)
            center_y = (screen_height // 2) - (text.get_height() // 2)
            screen.blit(text, [center_x, center_y])        
        
        self.draw_text(screen)
        
        pygame.display.flip()
        


def main():
    pygame.init()
 
    screen = pygame.display.set_mode([screen_width, screen_height])   
    
    game = Game()

    done = False
    
    clock = pygame.time.Clock()
    
    
    while not done:

        done = game.event_process()
        game.run_logic()
        game.display(screen)
        clock.tick(60)
    
    pygame.quit()
    

if __name__ == "__main__":
    main()